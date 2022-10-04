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
    [Header("Spawn Position")]
    [SerializeField] Vector3 spawnPos;

    [Header("Double Jump Shoes Collision Check")]
    public bool hasShoes;
    public bool usedDoubleJump;
    public Collider2D doubleJumpShoe;

    // Start is called before the first frame update
    void Start()
    {
        usedDoubleJump = false;
    }

    // Update is called once per frame
    public void Die()
    {
        //transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
        SceneManager.LoadScene("Level 1-1");
    }

    public void Pause()
    {
        GameManager.isPaused = !GameManager.isPaused;
        Debug.Log("PAUSED");
    }

    public void Win()
    {
        Die();
        Pause();
    }
}
