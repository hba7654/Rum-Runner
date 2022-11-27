using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Target : MonoBehaviour
{
    public enum TargetEffect
    {
        ChangeTilemapVToH, //Deleting vertical tiles and adding horizontal ones (like dropping a bridge)
        ChangeTilemapHToH, //Deleting horizontal tiles and adding horizontal ones (like moving a horizontal platform)
        ChangeTilemapHToV, //Deleting horizontal tiles and adding vertical ones (like raising a bridge)
        UnlockBottle //A bottle will activate somewhere in the level 
    }

    [SerializeField] public TargetEffect effect;

    [Header("Change Tilemap")]
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tile;
    [SerializeField] private Vector2Int tilemapStartPos;

    //Only use these when dealing with vertical tiles
    [Header("Vertical To Horizontal / Horizontal to Vertical")]
    [SerializeField] private int height;
    [SerializeField] private int length;

    //Only use these when purely dealing with horizontal tiles
    [Header("Horizontal To Horizontal")]
    [SerializeField] private int lengthToBeDeleted;
    [SerializeField] private int lengthToBeAdded;

    //Only use this when the target is unlockinga bottle
    [Header("Unlock Bottle")]
    [SerializeField] private GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {
        bottle.SetActive(false);
    }

    public void ChangeTilemapHtoV()
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

    public void ChangeTilemapVtoH()
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

    public void ChangeTilemapHtoH()
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

    public void UnlockBottle()
    {
        bottle.SetActive(true);
    }
}
