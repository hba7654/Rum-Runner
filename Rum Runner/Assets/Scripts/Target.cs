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
        bottle.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Debug.Log("Target HIT!");
            switch (effect)
            {
                case TargetEffect.ChangeTilemapVToH:
                    ChangeTilemapVtoH();
                    break;
                case TargetEffect.ChangeTilemapHToV:
                    ChangeTilemapHtoV();
                    break;
                case TargetEffect.ChangeTilemapHToH:
                    ChangeTilemapHtoH();
                    break;

                case TargetEffect.UnlockBottle:
                    UnlockBottle();
                    break;
            }

            Destroy(collision.gameObject);
        }
    }

    private void ChangeTilemapHtoV()
    {
        Debug.Log("changing tiles h to v");
        //Delete horizontal tiles
        if (length < 0)
        {
            for (int i = 0; i > length; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }

        //Add vertical tiles
        if (height < 0)
        {
            for (int i = 0; i > height; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x, tilemapStartPos.y + i, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
        else
        {
            for (int i = 0; i < height; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x, tilemapStartPos.y + i, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
    }

    private void ChangeTilemapVtoH()
    {
        Debug.Log("changing tiles v to h");
        //Delete vertical tiles
        if (height < 0)
        {
            for (int i = 0; i > height; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x, tilemapStartPos.y + i, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }
        else
        {
            for (int i = 0; i < height; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x, tilemapStartPos.y + i, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }

        //Add horizontal tiles
        if (length < 0)
        {
            for (int i = 0; i > length; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
    }

    private void ChangeTilemapHtoH()
    {
        Debug.Log("changing tiles h to h");
        //Delete first set of tiles
        if (lengthToBeDeleted < 0)
        {
            for (int i = 0; i > lengthToBeDeleted; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }
        else
        {
            for (int i = 0; i < lengthToBeDeleted; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, null);
            }
        }

        //Add new set of tiles
        if (lengthToBeAdded < 0)
        {
            for (int i = 0; i > lengthToBeAdded; i--)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
        else
        {
            for (int i = 0; i < lengthToBeAdded; i++)
            {
                Vector3Int addTilePos = new Vector3Int(tilemapStartPos.x + i, tilemapStartPos.y, 0);
                tilemap.SetTile(addTilePos, tile);
            }
        }
    }

    private void UnlockBottle()
    {
        bottle.SetActive(true);
    }
}
