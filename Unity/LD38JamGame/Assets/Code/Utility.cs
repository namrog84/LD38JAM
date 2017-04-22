using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TileType
{
    public const int NoBuilding = -1;
    /*terrain*/
    public const int Grass = 0;
    public const int Water = 1;
    public const int Dirt = 2;

    /*grass possibility*/
    public const int GrassFarm = 10;

    /*water possibility*/
    public const int WaterFarm = 20;
    public const int WaterConservation = 21;
    public const int WaterEnergy = 22;


    /*stone possibility*/
    public const int DirtEnergy = 30;


    /*hybrid possibility*/
    public const int SpacePort = 40;
    public const int RecreationPark = 41;

    /*any possibility*/
    public const int Apartment = 51;
};

public class TileInformation
{
    public GameObject GameObject;
    public TileInformation(GameObject g)
    {
        GameObject = g;
    }


};

public interface ITurnInterface
{
    // called at the end of a turn
    void EndTurn();

}

public class Utility {
    

    public static void Shuffle<T>(T[,] array)
    {
        int lengthRow = array.GetLength(1);

        for (int i = array.Length - 1; i > 0; i--)
        {
            int i0 = i / lengthRow;
            int i1 = i % lengthRow;

            int j = Random.Range(0, i + 1);
            int j0 = j / lengthRow;
            int j1 = j % lengthRow;

            T temp = array[i0, i1];
            array[i0, i1] = array[j0, j1];
            array[j0, j1] = temp;
        }
    }
    //debug utility
    public static string GetTileString(int id)
    {
        switch (id)
        {
            case TileType.NoBuilding: return "NoBuilding";
            case TileType.Grass: return "Grass";
            case TileType.Dirt: return "Dirt";
            case TileType.Water: return "Water";

            case TileType.GrassFarm: return "GrassFarm";

            case TileType.WaterConservation: return "WaterConservation";
            case TileType.WaterEnergy: return "WaterEnergy";
            case TileType.WaterFarm: return "WaterFarm";

            case TileType.DirtEnergy: return "DirtEnergy";

            case TileType.RecreationPark: return "RecreationPark";
            case TileType.Apartment: return "Apartment";
            case TileType.SpacePort: return "SpacePort";

            default:
                return "Not Found";
        };
    }


}
