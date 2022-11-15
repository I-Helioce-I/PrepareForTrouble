using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManagerTraining : MonoBehaviour
{
    // Logic
    private int tileCountX = 3;
    private int tileCountZ = 3;
    public GameObject[,] tiles;

    public GameObject prefab;

    public void Awake()
    {
        
    }

    public void GenerateAllTiles(PlayerControllerTraining pc, Transform[] spawns)
    {
        foreach (Transform spawn in spawns)
        {
            GenerateSingleTile(pc, spawn.transform.position.x, spawn.transform.position.z);
        }

        //tiles = new GameObject[tileCountX, tileCountZ];
        //for (int x = 0; x < tileCountX; x++)
        //{
        //    for (int z = 0; z < tileCountZ; z++)
        //    {
        //        tiles[x, z] = GenerateSingleTile(tileSize, x, z);
        //    }
        //}
    }

    private GameObject GenerateSingleTile(PlayerControllerTraining pc, float x, float z)
    {
        GameObject tileObject = Instantiate(prefab);
        tileObject.transform.parent = pc.transform;
        pc.myTerrain.Add(tileObject);
        tileObject.transform.position = new Vector3(x, 0, z);

        tileObject.layer = LayerMask.NameToLayer("MyTile");

        return tileObject;
    }
}
