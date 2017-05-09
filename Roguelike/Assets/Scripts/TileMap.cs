using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

    TileType[,] tileTypes;
    int[,] tiles;
    int mapSizeY = 10;
    int mapSizeX = 10;

    void Start()
    {
        //allocate our map tiles
        tiles = new int[mapSizeX, mapSizeY];
        //initialize our map tiles
        for (int x = 0; x < mapSizeX; x++) {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
    }

}
