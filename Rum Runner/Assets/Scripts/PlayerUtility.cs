using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUtility : MonoBehaviour
{
    [Header("Imported Objects")]
    public GameObject bullet;
    private Bullet bulletScript;
    public Camera mainCam;

    [Header("General Variables")]
    private Vector2 mousePosition;
    private Vector2 mouseDirVector;


    [Header("Shooting Variables")]
    private float bulletSpeed;

    [Header("Grappling Variables")]
    public LineRenderer lineRenderer;
    public float grappleLength;
    private PlayerMovement pMoveScript;
    //public DistanceJoint2D distJoint;

    public void Awake()
    {
        bulletSpeed = 5f;
        lineRenderer = GetComponent<LineRenderer>();
        pMoveScript = GetComponent<PlayerMovement>();
        //distJoint = GetComponent<DistanceJoint2D>();

        lineRenderer.enabled = false;
        //distJoint.enabled = false;


    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Fire();
        if (Mouse.current.rightButton.isPressed)
        {
            pMoveScript.isGrappling = true;
            Grapple();
        }
        else if(Mouse.current.rightButton.wasReleasedThisFrame)
        {
            pMoveScript.isGrappling = false;
            pMoveScript.moveVector = Vector2.zero;
        }
        //else
        //{
        //    distJoint.enabled = true;
        //}
    }

    public void Fire()
    {
        GameObject bulletClone;
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
        bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
        bulletScript = bulletClone.GetComponent<Bullet>();
        mouseDirVector = GetMouseVector();
        bulletScript.InitialMove(bulletSpeed, mouseDirVector);
    }

    public void Grapple()
    {
        mousePosition = GetMousePosition();
        mouseDirVector = GetMouseVector();

        Debug.Log(mousePosition);
        lineRenderer.SetPosition(0, mousePosition);
        lineRenderer.SetPosition(1, transform.position);
        //distJoint.connectedAnchor = mousePosition;
        //distJoint.enabled = true;
        lineRenderer.enabled = true;

        //if (distJoint.enabled)
        //{
        //    lineRenderer.SetPosition(1, transform.position);
        //}

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector, grappleLength, pMoveScript.groundLayer);
        Debug.Log(hit.collider.gameObject);
        if(hit.collider!= null)
        {
            pMoveScript.moveVector = mouseDirVector;
            //Vector2 vel =  pMoveScript.moveSpeed * mouseDirVector;
            //Debug.Log(vel);
            //pMoveScript.rb.velocity = vel;
            //Debug.Log(pMoveScript.rb.velocity.x);
        }
    }

    public Vector2 GetMouseVector()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x - playerPos.x, Worldpos.y - playerPos.y).normalized;
    }

    public Vector2 GetMousePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x, Worldpos.y);
    }


}
