using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> terrainTextures;

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

    [SerializeField]
    public Vector3 StartPoint = Vector3.zero; // W³aœciwoœæ okreœlaj¹ca punkt startowy, domyœlnie (0,0,0)

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
                    mapArray[posY, posX + 1] = 1;
                }
            }
        }
        catch (System.Exception)
        {

        }
    }

    void CreateMap()
    {
        int rand;
        int vertically;
        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                rand = UnityEngine.Random.Range(0, 13);
                if (rand > 2)
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
        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                if (mapArray[x, y] == 0)
                {
                    Instantiate(mapBlock, StartPoint + new Vector3(x * .8f, y * .8f, 0), Quaternion.identity, map.transform);
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
        // Górna i dolna œciana
        for (int x = -1; x <= mapSizeX; x++)
        {
            CreateBoundaryWall(StartPoint + new Vector3(x * .8f, -1 * .8f, 0)); // Dolna œciana
            CreateBoundaryWall(StartPoint + new Vector3(x * .8f, mapSizeY * .8f, 0)); // Górna œciana
        }

        // Lewa i prawa œciana
        for (int y = 0; y < mapSizeY; y++)
        {
            CreateBoundaryWall(StartPoint + new Vector3(-1 * .8f, y * .8f, 0)); // Lewa œciana
            CreateBoundaryWall(StartPoint + new Vector3(mapSizeX * .8f, y * .8f, 0)); // Prawa œciana
        }
    }

    void CreateBoundaryWall(Vector3 position)
    {
        GameObject boundaryWall = Instantiate(wallBlock, position, Quaternion.identity, map.transform);
        BoxCollider2D collider = boundaryWall.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(.4f, .4f);
        boundaryWall.tag = "BoundaryWall";
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
