using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [Header("Movement Variables")]
    private Vector2 currentVelocity;
    private float dartSpeed;
    private Rigidbody2D rb;



    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
    }

    public void InitialMove(float bSpeed, Vector2 initalVelocity)
    {
        Debug.Log("Intial Move has been called" + initalVelocity);
        currentVelocity = initalVelocity;
        dartSpeed = bSpeed;
        rb.velocity = new Vector2(currentVelocity.x * dartSpeed, currentVelocity.y * dartSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(gameObject);
    }
}
