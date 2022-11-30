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
    private Vector2 initialPos;
    


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cleanupCutX = 10f;
        cleanupCutY = 8f;
    }

    public void Update()
    {
        //checks position, if out of bounds destroy the object
        if (transform.position.x > initialPos.x + cleanupCutX || transform.position.x < initialPos.x - cleanupCutX
            || transform.position.y > initialPos.y + cleanupCutY || transform.position.y < initialPos.y - cleanupCutX)
        {
            Debug.Log("Destroying this object");
            Destroy(gameObject);
        }
    }

    public void InitialMove(float bSpeed, Vector2 initalVelocity)
    {
        Debug.Log("Intial Move has been called"+ initalVelocity);
        initialPos = transform.position;
        currentVelocity = initalVelocity;
        bulletSpeed = bSpeed;
        rb.velocity = new Vector2(currentVelocity.x * bulletSpeed, currentVelocity.y * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            Target target = collision.GetComponent<Target>();
            Debug.Log("Target HIT!");
            switch (target.effect)
            {
                case Target.TargetEffect.ChangeTilemapVToH:
                    target.ChangeTilemapVtoH();
                    break;

                case Target.TargetEffect.ChangeTilemapHToV:
                    target.ChangeTilemapHtoV();
                    break;

                case Target.TargetEffect.ChangeTilemapHToH:
                    target.ChangeTilemapHtoH(false);
                    break;

                case Target.TargetEffect.UnlockBottle:
                    target.UnlockBottle();
                    break;
            }

            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag != "Player")
            Destroy(gameObject);
    }
}
