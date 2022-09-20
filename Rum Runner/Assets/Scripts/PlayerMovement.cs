using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager playerManager;

    [Header("Movement Variables")]
    private Rigidbody2D rb;
    private Vector2 moveVector;
    public float jumpDistance;
    public float moveSpeed;
    [SerializeField] bool isFacingRight;

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
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
            }
            else if (!isGrounded && playerManager.hasShoes)
            {
                if (!playerManager.usedDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                    playerManager.usedDoubleJump =true;
                }
            }
            
        }
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundSpot.position, 0.1f, groundLayer);
        if (isGrounded)
        {
            playerManager.usedDoubleJump =false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
    }

    
}