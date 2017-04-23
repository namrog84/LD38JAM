using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UIType
{
    public const int Turn = 0;
    public const int People = 1;
    public const int Food = 2;
    public const int Energy = 3;
    public const int Happy = 4;
    public const int Water = 10;
}


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
    public static int GetBuildCost(int id)
    {
        switch (id)
        {
            case NoBuilding: return 0;
            case Grass: return 10;
            case Dirt: return 10;
            case Water: return 10;

            case GrassFarm: return 5;

            case WaterConservation: return 20;
            case WaterEnergy: return 5;
            case WaterFarm: return 4;

            case DirtEnergy: return 10;

            case RecreationPark: return 5;
            case Apartment: return 5;
            case SpacePort: return 100;

            default:
                throw new System.Exception("Utility>GetBuildCost>InvalidId");

        }

    }
    //debug utility
    public static string ToString(int id, bool includeToolTip = false)
    {
        switch (id)
        {
            case NoBuilding: return string.Format("No Building{0}\nCost: {1} Energy", includeToolTip?"":string.Empty, GetBuildCost(id));
            case Grass: return string.Format("Grass{0}\nCost: {1} Energy", includeToolTip ? " (Terraform)\n" : string.Empty, GetBuildCost(id));
            case Dirt: return string.Format("Dirt{0}\nCost: {1} Energy", includeToolTip ? " (Terraform)\n" : string.Empty, GetBuildCost(id));
            case Water: return string.Format("Water{0}\nCost: {1} Energy", includeToolTip ? " (Terraform)\n" : string.Empty, GetBuildCost(id));

            case GrassFarm: return string.Format("Grass Farm{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));

            case WaterConservation: return string.Format("Conservation Facility{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));
            case WaterEnergy: return string.Format("Hydroelectric Facility{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));
            case WaterFarm: return string.Format("Fishing Harbor{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));

            case DirtEnergy: return string.Format("DirtEnergy{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));

            case RecreationPark: return string.Format("Park & Recreation{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));
            case Apartment: return string.Format("Dwelling{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));
            case SpacePort: return string.Format("Space Port{0}\nCost: {1} Energy", includeToolTip ? "" : string.Empty, GetBuildCost(id));

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
