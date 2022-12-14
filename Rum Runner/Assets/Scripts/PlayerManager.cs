using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayerManager will contain manage what abilities can currently be used, as well as
/// have a score counter and a timer to keep track of player score
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public bool isFacingRight;

    [Header("Spawn Position")]
    [SerializeField] Vector3 spawnPos;

    [Header("Double Jump Shoes")]
    public bool hasShoes;
    public bool usedDoubleJump;
    public Collider2D doubleJumpShoe;

    [Header("Pistol")]
    public bool hasPistol;

    [Header("Grapple")]
    public bool hasGrapple;

    // Start is called before the first frame update
    void Start()
    {
        usedDoubleJump = false;
        isFacingRight = true;
    }
    private void Update()
    {
        if(!isFacingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
