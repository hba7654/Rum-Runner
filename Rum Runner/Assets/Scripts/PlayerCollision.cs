using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerManager playerManager;
    public SoundManager playerSound;

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

            playerSound.PlaySound("pickup");
        }
        else if (other.tag == "Pistol")
        {
            Debug.Log("Pistol picked up!");
            Destroy(other.gameObject);
            playerManager.hasPistol = true;

            playerSound.PlaySound("pickup");
        }
        else if (other.tag == "Collectable")
        {
            Debug.Log("Collectable picked up!");
            Destroy(other.gameObject);
            GameManager.rumBottles++;

            playerSound.PlaySound("bottle");
        }
        else if(other.tag == "Spikes")
        {
            playerSound.PlaySound("die");
            Debug.Log("HIT SPIKES");
            GameManager.Die();

        }
        else if (other.tag == "Exit")
        {
            Debug.Log("WIN!");
            GameManager.Win();
        }
        else if (other.tag == "Trigger")
        {
            playerSound.PlaySound("dart");
            Debug.Log("Shoot dart!");
            other.transform.parent.GetComponent<DartTrap>().isTriggered = true;
        }
    }
}
