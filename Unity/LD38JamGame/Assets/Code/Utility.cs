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

    public static float GetBaseResourcePerRound(int id)
    {
        switch (id)
        {
            //nothing
            case NoBuilding: return 0.0f;
            case Grass: return 0.0f;
            case Dirt: return 0.0f;
            case Water: return 0.0f;
           
            //food
            case GrassFarm: return 7.0f;
            case WaterFarm: return 5.0f;

            //water conservation
            case WaterConservation: return .05f;

            //energy
            case WaterEnergy: return 2.0f;
            case DirtEnergy: return 10.0f;

            //happiness
            case RecreationPark: return .02f;
            case Apartment: return 1.0f;
            //count
            case SpacePort: return 1.0f;

            default:
                throw new System.Exception("Utility>GetBuildCost>InvalidId");

        }
    }

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
            case SpacePort: return 1000;

            default:
                throw new System.Exception("Utility>GetBuildCost>InvalidId");

        }

    }
    //debug utility
    public static string ToString(int id, bool includeToolTip = false)
    {
        var append = string.Format("\nCost: {0} Energy", GetBuildCost(id));
        var formatString = string.Empty;
        var description = string.Empty;
        switch (id)
        {
            case NoBuilding:
                formatString = "No Building{0}";
                break;

            case Grass:
                formatString = includeToolTip ? "Remove Building {0}" :"Grass{0}";
                description = "\nThis will remove the building.";
                break;
            case Dirt:
                formatString = includeToolTip ? "Remove Building {0}" : "Dirt{0}" ;
                description = "\nThis will remove the building.";
                break;
            case Water:
                formatString = includeToolTip ? "Remove Building {0}" : "Water{0}";
                description = "\nThis will remove the building.";
                break;

            case GrassFarm:
                formatString = "Grass Farm{0}";
                description = string.Format("\nIncrease Base Food Production by {0}", GetBaseResourcePerRound(GrassFarm));
                break;

            case WaterConservation:
                formatString = "Conservation Facility{0}";
                description = string.Format("\nReduce Water Consumption by {0}", GetBaseResourcePerRound(WaterConservation));
                break;
            case WaterEnergy:
                formatString = "Hydroelectric Facility{0}";
                description = string.Format("\nIncrease Base Energy Production by {0}", GetBaseResourcePerRound(WaterEnergy));
                break;
            case WaterFarm:
                formatString = "Fishing Harbor{0}";
                description = string.Format("\nIncrease Base Food Production by {0}", GetBaseResourcePerRound(WaterEnergy));
                break;

            case DirtEnergy:
                formatString = "Nuclear Plant{0}";
                description = string.Format("\nIncrease Base Energy Production by {0}", GetBaseResourcePerRound(WaterEnergy));
                break;

            case RecreationPark:
                formatString = "Parks & Recreation{0}";
                description = string.Format("\nIncrease Happiness by {0} per turn", GetBaseResourcePerRound(WaterEnergy));
                break;
            case Apartment:
                formatString = "Dwelling{0}";
                description = string.Format("\nIncrease Happiness by {0} per turn", GetBaseResourcePerRound(Apartment));
                break;
            case SpacePort:
                formatString = "Space Port{0}";
                description = string.Format("\nWin the Game! Leave the planet!");
                break;

            default:
                return "Not Found";
        };
        return string.Format(formatString, includeToolTip ? description + append : string.Empty);
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
