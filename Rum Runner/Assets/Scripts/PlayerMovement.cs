using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;

    [Header("Movement Variables")]
    public Rigidbody2D rb;
    public Vector2 moveVector;
    private bool canJump;
    public float jumpDistance;
    public float jumpingGravity;
    public float fallingGravity;
    public float moveSpeed;
    [SerializeField] float coyoteTime;
    private float coyoteTimeLeft;
    [SerializeField] bool isFacingRight;
    private bool hasMoved;
    public bool isGrappling;

    [Header("Ground Check")]
    [SerializeField] bool isGrounded;
    public Transform groundSpot;
    public LayerMask groundLayer;


    private float normalGravity;

    private void Awake()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();

        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        isFacingRight = true;
        hasMoved = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(!hasMoved)
        {
            hasMoved = true;
            GameManager.hasStarted = true;
        }
        if(!isGrappling)
            moveVector = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && !GameManager.isPaused)
        {
            
            if (canJump)
            {
                rb.gravityScale = jumpingGravity;
                rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
            }
            else if (!canJump && playerManager.hasShoes)
            {
                if (!playerManager.usedDoubleJump)
                {
                    rb.gravityScale = jumpingGravity;
                    rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                    playerManager.usedDoubleJump =true;
                }
            }
            
        }
        else if(context.canceled && !isGrounded)
        {
            rb.gravityScale = fallingGravity;
        }
        
    }

    private void Update()
    {
        if (!GameManager.isPaused)
        {
            isGrounded = Physics2D.OverlapCircle(groundSpot.position, 0.1f, groundLayer);
            if (isGrounded)
            {
                coyoteTimeLeft = coyoteTime;
                canJump = true;
                playerManager.usedDoubleJump = false;
            }
            else
            {
                coyoteTimeLeft -= Time.deltaTime;
                if (coyoteTimeLeft <= 0)
                {
                    coyoteTimeLeft = 0;
                    canJump = false;
                }
            }
        }


        if(rb.velocity.y <= 0)
        {
            rb.gravityScale = fallingGravity;
        }
        else
        {
            rb.gravityScale = jumpingGravity;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.isPaused)
        {
            if(isGrappling)
                rb.velocity = new Vector2(moveVector.x * moveSpeed, moveVector.y * moveSpeed);
            else
                rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);

        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
    }

    
}