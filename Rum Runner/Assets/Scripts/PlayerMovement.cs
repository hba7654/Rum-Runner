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
    public LayerMask shoeLayer;
    private bool usedDoubleJump;



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
            
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundSpot.position, 0.1f, groundLayer);
        hasShoes = Physics2D.OverlapCapsule(transform.position, new Vector2(1,2), CapsuleDirection2D.Vertical, shoeLayer);
        //Debug.Log( Physics2D.OverlapCircle(transform.position, 0.2f, shoeLayer));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
    }

}