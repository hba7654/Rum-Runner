using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Movement Variables")]
    private Vector2 currentVelocity;
    private float bulletSpeed;
    private Rigidbody2D rb;
    

    [Header("Cleanup Variables")]
    //This is for cleaning up created bullets when the pass a certain point
    private float cleanupCutX;
    private float cleanupCutY;
    


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cleanupCutX = 15f;
        cleanupCutY = 19f;
    }

    public void Update()
    {
        //checks position, if out of bounds destroy the object
        if(transform.position.x>cleanupCutX|| transform.position.x < -cleanupCutX
            || transform.position.y > cleanupCutY || transform.position.y < -cleanupCutX)
        {
            Debug.Log("Destroying this object");
            Destroy(gameObject);
        }
    }

    public void InitialMove(float bSpeed, Vector2 initalVelocity)
    {
        Debug.Log("Intial Move has been called"+ initalVelocity);
        currentVelocity = initalVelocity;
        bulletSpeed = bSpeed;
        rb.velocity = new Vector2(currentVelocity.x * bulletSpeed, currentVelocity.y * bulletSpeed);
    }
}
