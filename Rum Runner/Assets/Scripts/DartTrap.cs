using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{
    private GameObject shooter, trigger;

    [SerializeField] private bool isFacingRight;
    [SerializeField] private float dartSpeed;
    [SerializeField] private GameObject dart;

    public bool isTriggered;
    

    private void Awake()
    {
        shooter = transform.GetChild(0).gameObject;
        trigger = transform.GetChild(1).gameObject;

        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        isTriggered = false;
        GameObject dartClone;
        Vector2 dartSpawnPosition = new Vector2(shooter.transform.position.x + 0.5f, shooter.transform.position.y);
        dartClone = Instantiate(dart, dartSpawnPosition, transform.rotation);
        dartClone.GetComponent<Rigidbody2D>().velocity = isFacingRight ? dartSpeed * shooter.transform.right : dartSpeed * -shooter.transform.right;
    }
}
