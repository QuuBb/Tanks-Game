using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> terainTextures;

    [SerializeField]
    List<Sprite> wallTextures;

    [SerializeField]
    int mapSizeX = 10;
    [SerializeField]
    int mapSizeY = 10;

    int[,] mapArray;

    public GameObject mapBlock;
    public GameObject wallBlock;
    public GameObject map;

    void CreateWall(int posX, int posY, int vertically)
    {
        try
        {
            if(vertically == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    mapArray[posY+i, posX] = 1;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    mapArray[posY, posX+1] = 1;
                }
            }
        } catch( Exception _) 
        {
        
        }
    }

    void CreateMap()
    {
        int rand;
        int vertically;
        for(int y = 0; y < mapSizeY; y++) 
        {
            for(int x = 0; x < mapSizeX; x++)
            {
                rand = UnityEngine.Random.Range(0, 10);
                if(rand > 2)
                {
                    mapArray[x, y] = 0;
                }
                else
                {
                    vertically = UnityEngine.Random.Range(0, 2);
                    CreateWall(x, y, vertically);
                }
            }
        }
    }

    void RenderMap()
    {
        for (int y = -5; y < mapSizeY - 5; y++)
        {
            for (int x = -5; x < mapSizeX - 5; x++)
            {
                if (mapArray[x+5, y+5] == 0)
                {
                    Instantiate(mapBlock, new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);
                }
                else
                {
                    Instantiate(wallBlock, new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);
                }
            }
        }
    }


    void Start()
    {
        mapArray = new int[mapSizeY, mapSizeX];
        CreateMap();
        RenderMap();
    }

    void Update()
    {
        
    }
}
