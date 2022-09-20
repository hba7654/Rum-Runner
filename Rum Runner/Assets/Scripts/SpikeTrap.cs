using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.SetPositionAndRotation(new Vector3(-8.5f, -2, 0) ,Quaternion.identity);
        }
    }
}
