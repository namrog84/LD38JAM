using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TerrainGen : MonoBehaviour
{
    public GameObject[] miscTerrain;
    // Grass 0
    // Water 1
    // Dirt/Rock 2

    public int horizontalTileCount = 13;
    public int verticalTileCount = 10;

    public float startOffsetX = 2.0f;
    public float startOffsetY = 2.0f;

    public int[,] worldTiles;

    public float grassPercentage = 0.6f;
    public float waterPercentage = 0.2f;
    public float dirtPercentage = 0.4f;

    private float tileOffset = 4.0f;
    private float[] weights;
    private float weightTotal;

    public void generateWeights()
    {
        weights = new float[4];

        //weighting of each thing, high number means more occurrance
        weights[TileType.Grass] = grassPercentage;
        weights[TileType.Water] = waterPercentage;
        weights[TileType.Dirt] = dirtPercentage;

        weightTotal = weights.Sum();
    }

    int GenerateRandomTile()
    {
        int result = 0;
        float total = 0;
        float randVal = Random.Range(0.0f, weightTotal);
        for (result = 0; result < weights.Length; result++)
        {
            total += weights[result];
            if (total > randVal)
            {
                break;
            }
        }
        return result;
    }

    void Start()
    {
        generateWeights();

        worldTiles = new int[horizontalTileCount, verticalTileCount];

        for (int j = 0; j < verticalTileCount; j++)
        {
            for (int i = 0; i < horizontalTileCount; i++)
            {
                var tile = GenerateRandomTile();
                worldTiles[i, j] = tile;

                var tempObject = Instantiate(miscTerrain[tile]);
                tempObject.transform.position = new Vector3(tileOffset * i + startOffsetX, tileOffset * j + startOffsetY, 1);
                tempObject.transform.parent = this.transform;
                InitializeTile(tempObject, tile, i, j);

            }
        }
    }

    public void InitializeTile(GameObject obj, int type, int x, int y)
    {
        var GameBoard = GameGod.Instance.GameBoard;
        var tileObject = obj.GetComponent<BuildTile>();
        var newTileId = GameBoard.Count;
        tileObject.InitializeObject(type, newTileId);


        var tileInfo = new TileInformation(obj);

        tileInfo.NorthId = y + 1 < verticalTileCount ? horizontalTileCount * (y + 1) + x : -1;
        tileInfo.SouthId = y - 1 >= 0  ? horizontalTileCount * (y - 1) + x : -1;

        tileInfo.EastId = x + 1 < horizontalTileCount ? (horizontalTileCount * y + (x + 1)) : -1;
        tileInfo.WestId = x - 1 >= 0 ? horizontalTileCount * y + (x - 1) : -1;


        //tileInfo.EastId = newTileId + 1;
        //tileInfo.WestId = newTileId - 1;

        GameBoard.Add(tileInfo);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

