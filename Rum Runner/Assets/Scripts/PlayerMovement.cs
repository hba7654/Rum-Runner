using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

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

    [Header("Double Jump Shoes Collision Check")]
    [SerializeField] bool hasShoes;
    private bool usedDoubleJump;
    public Collider2D doubleJumpShoe;



    private float normalGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        isFacingRight = true;
        usedDoubleJump = false;
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
            else if (!isGrounded && hasShoes)
            {
                if (!usedDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                    usedDoubleJump=true;
                }
            }
            
        }
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundSpot.position, 0.1f, groundLayer);
        if (isGrounded)
        {
            usedDoubleJump=false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shoes"))
        {
            Debug.Log("collide w Shoes");
            hasShoes = true;
            Destroy(other.gameObject);
        } 
    }
}