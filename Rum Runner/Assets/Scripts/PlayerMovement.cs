  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator animator;

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
    public bool isMoving;
    public bool isGrappling;

    [Header("Ground Check")]
    [SerializeField] bool isGrounded;
    public Transform groundSpot;
    public LayerMask groundLayer;

    public SoundManager playerSound;
    private float normalGravity;

    private void Awake()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started && !isGrappling)
        {
            playerSound.PlaySound("run");
            isMoving = true;
        }
        else if (context.canceled)
        {
            playerSound.StopSound("run");
            isMoving = false;
        }
        if (!GameManager.hasStarted)
        {
            GameManager.hasStarted = true;
            moveVector = Vector2.zero;
        }
        if (!isGrappling)
        {
            moveVector = context.ReadValue<Vector2>();
        }
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started && !GameManager.isPaused)
        {
            
            if (canJump)
            {
                rb.gravityScale = jumpingGravity;
                rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                playerSound.PlaySound("jump");
            }
            else if (!canJump && playerManager.hasShoes)
            {
                if (!playerManager.usedDoubleJump)
                {
                    rb.gravityScale = jumpingGravity;
                    rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                    playerManager.usedDoubleJump =true;
                    playerSound.PlaySound("jump");
                }
            }
            
        }
        if(context.canceled && !isGrounded)
        {
            rb.gravityScale = fallingGravity;
        }
        
    }

    private void Update()
    {
        if (!GameManager.isPaused)
        {
            if(!isMoving && !isGrappling && isGrounded)
            {
                moveVector = Vector2.zero;
            }

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
            if(moveVector.x > 0)
            {
                playerManager.isFacingRight = true;
            }
            else if(moveVector.x < 0)
            {
                playerManager.isFacingRight= false;
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
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("moving", isMoving);
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