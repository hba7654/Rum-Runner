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


    [Header("Shooting Variables")]
    private float bulletSpeed;

    [Header("Grappling Variables")]
    public LineRenderer lineRenderer;
    //public DistanceJoint2D distJoint;

    public void Awake()
    {
        bulletSpeed = 5f;
        lineRenderer = GetComponent<LineRenderer>();
        //distJoint = GetComponent<DistanceJoint2D>();

        lineRenderer.enabled = false;
        //distJoint.enabled = false;


    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Fire();
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Grapple();
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
        mousePosition = GetMousePosition();
        bulletScript.InitialMove(bulletSpeed, mousePosition.normalized);
    }

    public void Grapple()
    {
        mousePosition = GetMousePosition();

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
    }

    public Vector2 GetMousePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x- playerPos.x,Worldpos.y - playerPos.y);
    }


}
