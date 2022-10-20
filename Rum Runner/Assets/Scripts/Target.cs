using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Target : MonoBehaviour
{
    private enum TargetEffect
    {
        ChangeTilemap,
        UnlockBottle
    }

    [SerializeField] private TargetEffect effect;

    [Header("Change Tilemap")]
    [SerializeField] private Vector2 tilemapStartPos;
    [SerializeField] private Vector2 oldTilemapEndPos;
    [SerializeField] private Vector2 newTilemapEndPos;
    [SerializeField] private Tile tile;


    [Header("Unlock Bottle")]
    [SerializeField] private GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            switch (effect)
            {
                case TargetEffect.ChangeTilemap:
                    ChangeTilemap();
                    break;

                case TargetEffect.UnlockBottle:
                    UnlockBottle();
                    break;
            }
        }
    }

    private void ChangeTilemap()
    {

    }

    private void UnlockBottle()
    {
        throw new NotImplementedException();
    }
}
