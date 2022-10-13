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

    public void Fire()
    {
        GameObject bulletClone;
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x + 0.5f, transform.position.y);
        bulletClone = Instantiate(bullet, bulletSpawnPosition, transform.rotation);
        bulletScript = bulletClone.GetComponent<Bullet>();
        mousePosition = GetMousePosition();
        bulletScript.InitialMove(bulletSpeed, mousePosition.normalized);
    }

    public Vector2 GetMousePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(Worldpos.x- playerPos.x,Worldpos.y - playerPos.y);
    }


}
