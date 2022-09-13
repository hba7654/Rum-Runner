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

    private float normalGravity;

    private void Awake()
    {
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
        if(context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundSpot.position, 0.1f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
    }

}