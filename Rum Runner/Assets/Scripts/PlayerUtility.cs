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
    private GameObject crosshair;

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
        crosshair = playerManager.transform.GetChild(1).gameObject;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
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
        //Always update mouse position and direction if mouse is enabled
        if(usingMouse)
        {
            if (!isGrappling)
            {
                mousePosition = GetMousePosition();
                mouseDirVector = GetMouseVector();
            }
            crosshair.transform.position = mousePosition;
        }
        if(!usingMouse && isAiming)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector);
            if(hit.collider != null)
            {
                crosshair.transform.position = hit.point;
            }
        }
    }

    private void FixedUpdate()
    {
        //Handling grappling
        if (isGrappling)
        {
            //Begin grappling
            if (!startedGrappling)
            {
                startedGrappling = true;
                //Checks if grappling surface is within range
                RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirVector, grappleLength, pMoveScript.groundLayer);
                if (hit.collider != null)
                {
                    soundManager.PlaySound("grapple");
                    mousePosition = hit.point;
                    allowGrappling = true;
                    pMoveScript.isGrappling = true;
                }
            }
            //Proceed with grappling if possible
            if (allowGrappling)
            {
                //Draw the line
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, mousePosition);

                //Set the velocity direction
                pMoveScript.moveVector = mouseDirVector;

                //Proximity handling, grappling gets disabled when player gets close to surface
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
                isAiming = true;
                usingMouse = true;
                crosshair.SetActive(true);
            }
            //Controller Controls
            else if (context.control.displayName == "Right Stick")
            {
                mouseDirVector = context.ReadValue<Vector2>();
                mouseDirVector.x = Mathf.Round(mouseDirVector.x * 50) / 50;
                mouseDirVector.y = Mathf.Round(mouseDirVector.y * 50) / 50;

                isAiming = true;
                usingMouse = false;
                crosshair.SetActive(true);
            }
        }

        if(context.canceled)
        {
            isAiming = false;
            crosshair.SetActive(false);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        //Can only shoot when game is going and player is aiming
        if (GameManager.hasStarted && context.started && isAiming && playerManager.hasPistol)
        {
            soundManager.PlaySound("shoot");
            GameObject bulletClone;
            Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
            bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
            bulletScript = bulletClone.GetComponent<Bullet>();
            bulletScript.InitialMove(bulletSpeed, mouseDirVector);
        }
    }


    public void Grapple(InputAction.CallbackContext context)
    {
        //Can only grapple when game is going and player is aiming
        if (GameManager.hasStarted && isAiming && playerManager.hasGrapple)
        {
            //On input start, initiate grapple
            if (context.started)
            {
                isGrappling = true;
                pMoveScript.isMoving = false;
            }
            
            //On input end, reset all variables to do with grapple
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

    //Gets the Aiming direction for mouse
    public Vector2 GetMouseVector()
    {

        Vector3 playerPos = transform.position;
        return new Vector2(mousePosition.x - playerPos.x, mousePosition.y - playerPos.y).normalized;
    }

    //get mouse position on the screen
    public Vector2 GetMousePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x, Worldpos.y);
    }


}
