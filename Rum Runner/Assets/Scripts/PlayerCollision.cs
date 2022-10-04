using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shoes"))
        {
            Debug.Log("collide w Shoes");
            playerManager.hasShoes = true;
            Destroy(other.gameObject);
        }
        else if(other.tag == "Collectable")
        {
            Debug.Log("Collectable picked up!");
            Destroy(other.gameObject);
            GameManager.rumBottles++;
        }
        else if(other.tag == "Spikes")
        {
            Debug.Log("HIT SPIKES");
            playerManager.Die();
        }
        else if (other.tag == "Exit")
        {
            Debug.Log("WIN!");
            GameManager.isPaused = true;
        }
    }
}
