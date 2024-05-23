using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] List<Sprite> terrainTextures;
    [SerializeField] List<Sprite> wallTextures;
    [SerializeField] int mapSizeX = 10;
    [SerializeField] int mapSizeY = 10;
    int[,] mapArray;
    public GameObject mapBlock;
    public GameObject mapBlock2;
    public GameObject mapBlock3;
    public GameObject wallBlock;
    public GameObject BedRock;
    public GameObject map;
    [SerializeField] public Vector3 StartPoint = Vector3.zero;

    void CreateWall(int posX, int posY, int vertically)
    {
        try
        {
            if (vertically == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    mapArray[posY + i, posX] = 1;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    mapArray[posY, posX + i] = 1;
                }
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("Error creating wall at position: " + posX + ", " + posY);
        }
    }

    void CreateMap()
    {
        mapArray = new int[mapSizeY, mapSizeX]; // Inicjalizacja tablicy mapy

        int rand;
        int vertically;

        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                // Warunek zapewniaj¹cy, ¿e w lewym dolnym rogu (0, mapSizeY - 1) i prawym górnym rogu (mapSizeX - 1, 0) nie bêd¹ generowane œciany
                if ((x == 0 && y == mapSizeY - 1) || (x == mapSizeX - 1 && y == 0))
                {
                    mapArray[y, x] = 0; // Ustawienie na 0, aby nie generowaæ œcian w tych pozycjach
                }
                else
                {
                    rand = UnityEngine.Random.Range(0, 11);
                    if (rand > 2)
                    {
                        mapArray[y, x] = 0; // Ustawienie na 0, aby tworzyæ bloki terenu
                    }
                    else
                    {
                        vertically = UnityEngine.Random.Range(0, 2);
                        CreateWall(x, y, vertically); // Tworzenie œcian w pozosta³ych przypadkach
                    }
                }
            }
        }
    }



    void RenderMap()
    {
        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                if (mapArray[y, x] == 0)
                {
                    int RNG = UnityEngine.Random.Range(0, 100);

                    if(RNG>=0 && RNG<=15)
                    {
                        Instantiate(mapBlock2, StartPoint + new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);

                    }
                    else if(RNG > 15 && RNG <= 30)
                    {
                        Instantiate(mapBlock3, StartPoint + new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);

                    }
                    else
                    {
                        Instantiate(mapBlock, StartPoint + new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);

                    }


                }
                else
                {
                    GameObject newWall = Instantiate(wallBlock, StartPoint + new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);
                    BoxCollider2D collider = newWall.AddComponent<BoxCollider2D>();
                    collider.size = new Vector2(.4f, .4f);
                    newWall.tag = "Wall";
                }
            }
        }
        AddBoundaryWalls();
    }

    void AddBoundaryWalls()
    {
        for (int x = -1; x <= mapSizeX; x++)
        {
            CreateBoundaryWall(StartPoint + new Vector3(x * .8f, -1 * .8f, 0));
            CreateBoundaryWall(StartPoint + new Vector3(x * .8f, mapSizeY * .8f, 0));
        }

        for (int y = 0; y < mapSizeY; y++)
        {
            CreateBoundaryWall(StartPoint + new Vector3(-1 * .8f, y * .8f, 0));
            CreateBoundaryWall(StartPoint + new Vector3(mapSizeX * .8f, y * .8f, 0));
        }
    }

    void CreateBoundaryWall(Vector3 position)
    {
        GameObject boundaryWall = Instantiate(BedRock, position, Quaternion.identity, map.transform);
        BoxCollider2D collider = boundaryWall.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(.4f, .4f);
        boundaryWall.tag = "BoundaryWall";
    }

    void Start()
    {
        CreateMap();
        RenderMap();
    }
}
