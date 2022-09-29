using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUtility : MonoBehaviour
{
    [Header("Imported Objects")]
    public GameObject bullet;
    private Bullet bulletScript;
    public Camera mainCam;

    [Header("General Variables")]
    private Vector2 mousePosition;


    [Header("Shooting Variables")]
    private float bulletSpeed;

    public void Awake()
    {
        bulletSpeed = 5f;
       
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Fire();
    }

    public void Fire()
    {
        GameObject bulletClone;
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
        bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
        bulletScript = bulletClone.GetComponent<Bullet>();
        //mousePosition = GetMousePosition();
        bulletScript.InitialMove(bulletSpeed, new Vector2(1f,0f));
    }

    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }


}
