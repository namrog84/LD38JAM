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

    //debug utility
    public static string ToString(int id)
    {
        switch (id)
        {
            case NoBuilding: return "NoBuilding";
            case Grass: return "Grass";
            case Dirt: return "Dirt";
            case Water: return "Water";

            case GrassFarm: return "GrassFarm";

            case WaterConservation: return "WaterConservation";
            case WaterEnergy: return "WaterEnergy";
            case WaterFarm: return "WaterFarm";

            case DirtEnergy: return "DirtEnergy";

            case RecreationPark: return "RecreationPark";
            case Apartment: return "Apartment";
            case SpacePort: return "SpacePort";

            default:
                return "Not Found";
        };
    }

    public static List<int> GetIdList()
    {
        return new List<int> {
            RecreationPark, Apartment, SpacePort,
            DirtEnergy, GrassFarm,
            WaterEnergy, WaterFarm, WaterConservation,
            Water, Grass, Dirt };
    }

};

public class TileInformation
{
    public GameObject GroundTileObject;
    public int NorthId;
    public int SouthId;
    public int EastId;
    public int WestId;

    public TileInformation(GameObject g)
    {
        GroundTileObject = g;
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
  


}
