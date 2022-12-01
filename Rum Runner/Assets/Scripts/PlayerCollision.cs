using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerManager playerManager;
    public SoundManager playerSound;
    public GameManager gameManager;

    private void Start()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shoes"))
        {
            playerManager.hasShoes = true;
            other.gameObject.SetActive(false);

            playerSound.PlaySound("pickup");
        }
        else if (other.tag == "Pistol")
        {
            other.gameObject.SetActive(false);
            playerManager.hasPistol = true;

            playerSound.PlaySound("pickup");
        }
        else if (other.tag == "Grapple")
        {
            other.gameObject.SetActive(false);
            playerManager.hasGrapple = true;

            playerSound.PlaySound("pickup");
        }
        else if (other.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            GameManager.rumBottles++;

            playerSound.PlaySound("bottle");
        }
        else if(other.tag == "Spikes" || other.tag == "Dart")
        {
            playerSound.PlaySound("die");
            gameManager.Die();

        }
        else if (other.tag == "Exit")
        {
            GameManager.Win();
        }
        else if (other.tag == "Trigger")
        {
            playerSound.PlaySound("dart");
            other.transform.parent.GetComponent<DartTrap>().isTriggered = true;
        }
    }
}
