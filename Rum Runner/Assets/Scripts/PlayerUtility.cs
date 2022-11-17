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
    private PlayerManager playerManager;

    [Header("General Variables")]
    private Vector2 mousePosition;
    private Vector2 mouseDirVector;
    public SoundManager soundManager;


    [Header("Shooting Variables")]
    [SerializeField] private float bulletSpeed;

    [Header("Grappling Variables")]
    public LineRenderer lineRenderer;
    public float grappleLength;
    private PlayerMovement pMoveScript;
    //public DistanceJoint2D distJoint;

    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
       
        lineRenderer = GetComponent<LineRenderer>();
        pMoveScript = GetComponent<PlayerMovement>();
        //distJoint = GetComponent<DistanceJoint2D>();

        lineRenderer.enabled = false;
        //distJoint.enabled = false;


    }

    private void Update()
    {
        if (GameManager.hasStarted)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && playerManager.hasPistol)
                Fire();
            if (playerManager.hasGrapple)
            {
                if (Mouse.current.rightButton.wasPressedThisFrame)
                {
                    OnGrapple();
                }
                else if (Mouse.current.rightButton.isPressed)
                {
                    Grapple();
                }
                else if (Mouse.current.rightButton.wasReleasedThisFrame)
                {
                    pMoveScript.isGrappling = false;
                    pMoveScript.moveVector = Vector2.zero;
                }
            }
        }
    }

    public void Fire()
    {
        soundManager.PlaySound("shoot");
        mousePosition = GetMousePosition();
        GameObject bulletClone;
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
        bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
        bulletScript = bulletClone.GetComponent<Bullet>();
        mouseDirVector = GetMouseVector();
        bulletScript.InitialMove(bulletSpeed, mouseDirVector);
    }

    private void OnGrapple()
    {
        mousePosition = GetMousePosition();
        Debug.Log(mousePosition);

    }

    public void Grapple()
    {

        mouseDirVector = GetMouseVector();
        //distJoint.connectedAnchor = mousePosition;
        //distJoint.enabled = true;
        lineRenderer.enabled = true;

        //if (distJoint.enabled)
        //{
        //    lineRenderer.SetPosition(1, transform.position);
        //}

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector, grappleLength, pMoveScript.groundLayer);
        if(hit.collider!= null)
        {
            mousePosition = hit.point;
            Debug.Log(hit.transform.gameObject.ToString());
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            pMoveScript.isGrappling = true;
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
        //Vector3 mousePos = Mouse.current.position.ReadValue();
        //Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(mousePosition.x - playerPos.x, mousePosition.y - playerPos.y).normalized;
    }

    public Vector2 GetMousePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x, Worldpos.y);
    }


}
