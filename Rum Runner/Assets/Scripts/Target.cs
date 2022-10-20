using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Target : MonoBehaviour
{
    private enum TargetEffect
    {
        ChangeTilemapVToH,
        ChangeTilemapHToH,
        ChangeTilemapHToV,
        UnlockBottle
    }

    [SerializeField] private TargetEffect effect;

    [Header("Change Tilemap")]
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tile;
    [SerializeField] private Vector2Int tilemapStartPos;

    [Header("Vertical To Horizontal / Horizontal to Vertical")]
    [SerializeField] private int height;
    [SerializeField] private int length;

    [Header("Horizontal To Horizontal")]
    [SerializeField] private int lengthToBeDeleted;
    [SerializeField] private int lengthToBeAdded;

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
            Debug.Log("Target HIT!");
            switch (effect)
            {
                case TargetEffect.ChangeTilemapVToH:
                case TargetEffect.ChangeTilemapHToH:
                case TargetEffect.ChangeTilemapHToV:
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
        Debug.Log("changing tiles");
        for (int i = 0; i > lengthToBeDeleted; i--)
        {
            Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
            tilemap.SetTile(addTilePos, null);
        }
        for (int i = 0; i < lengthToBeAdded; i++)
        {
            Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
            tilemap.SetTile(addTilePos, tile);
        }
    }

    private void UnlockBottle()
    {
        throw new NotImplementedException();
    }
}
