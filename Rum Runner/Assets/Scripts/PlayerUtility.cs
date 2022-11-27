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
    private bool isAiming;
    private bool usingMouse;


    [Header("Shooting Variables")]
    [SerializeField] private float bulletSpeed;

    [Header("Grappling Variables")]
    public LineRenderer lineRenderer;
    public float grappleLength;
    private PlayerMovement pMoveScript;
    private bool isGrappling;
    private bool startedGrappling;
    private bool allowGrappling;

    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();

        lineRenderer = GetComponent<LineRenderer>();
        pMoveScript = GetComponent<PlayerMovement>();

        isAiming = false;
        usingMouse = false;

        mouseDirVector = Vector2.right;

        lineRenderer.enabled = false;
        isGrappling = false;
        startedGrappling = false;
        allowGrappling = false;

    }

    private void Update()
    {
        Debug.Log("Is Aiming: " + isAiming);
        if(usingMouse && !isGrappling)
        {
            mousePosition = GetMousePosition();
            mouseDirVector = GetMouseVector();
        }
        if(isGrappling)
        {
            if (!startedGrappling)
            {
                startedGrappling = true;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector, grappleLength, pMoveScript.groundLayer);
                mousePosition = hit.point;
                if (hit.collider != null)
                {
                    allowGrappling = true;
                    pMoveScript.isGrappling = true;
                }
            }
            if(allowGrappling)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, mousePosition);
                pMoveScript.moveVector = mouseDirVector;
                Vector2 distance = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);

                if (distance.magnitude <= 1)
                {
                    isGrappling = false;
                    startedGrappling = false;
                    allowGrappling = false;
                    pMoveScript.isGrappling = false;
                    lineRenderer.enabled = false;
                }
            }
        }
    }

    //Aiming controls for mouse and controller
    public void Look(InputAction.CallbackContext context)
    {
        if(!isGrappling) //Player shouldn't be able to aim when grappling
        {
            //Mouse Controls
            if (context.control.displayName == "Position")
            {
                mousePosition = GetMousePosition();
                mouseDirVector = GetMouseVector();
                isAiming = true;
                usingMouse = true;
            }
            //Controller Controls
            else if (context.control.displayName == "Right Stick")
            {
                Debug.Log("Direction: " + mouseDirVector);
                mouseDirVector = context.ReadValue<Vector2>();

                // Deadzone
                isAiming = true;
                if (mouseDirVector.magnitude <= 0.25f)
                    isAiming = false;

                usingMouse = false;
            }
        }
                if(context.canceled)
                {
                    isAiming = false;
                }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (GameManager.hasStarted && context.started && isAiming)
        {
            soundManager.PlaySound("shoot");
            //mousePosition = GetMousePosition();
            GameObject bulletClone;
            Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
            bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
            bulletScript = bulletClone.GetComponent<Bullet>();
            //mouseDirVector = GetMouseVector();
            bulletScript.InitialMove(bulletSpeed, mouseDirVector);
        }
    }

    //private void OnGrapple()
    //{
    //    mousePosition = GetMousePosition();
    //    Debug.Log(mousePosition);

    //}

    // public void Grapple()
    // {

    //     mouseDirVector = GetMouseVector();
    //     //distJoint.connectedAnchor = mousePosition;
    //     //distJoint.enabled = true;
    //     lineRenderer.enabled = true;

    //     //if (distJoint.enabled)
    //     //{
    //     //    lineRenderer.SetPosition(1, transform.position);
    //     //}

    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector, grappleLength, pMoveScript.groundLayer);
    //     if(hit.collider!= null)
    //     {
    //         if (mouseDirVector == Vector2.zero)
    //             mouseDirVector = lastMouseDirVector.normalized;
    //         //mousePosition = GetMousePosition();
    //         GameObject bulletClone;
    //         Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
    //         bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
    //         bulletScript = bulletClone.GetComponent<Bullet>();
    //         //mouseDirVector = GetMouseVector();
    //         bulletScript.InitialMove(bulletSpeed, mouseDirVector);
    //     }
    // }


    public void Grapple(InputAction.CallbackContext context)
    {
        if (GameManager.hasStarted && isAiming)
        {
            if (context.started)
            {
                isGrappling = true;
            }
            
            else if (context.canceled)
            {
                isGrappling = false;
                startedGrappling = false;
                allowGrappling = false;
                pMoveScript.isGrappling = false;
                lineRenderer.enabled = false;
            }
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
