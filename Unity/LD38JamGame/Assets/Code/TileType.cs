using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType
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
    public const int GrassPark = 41;
    public const int DirtPark = 42;


    /*any possibility*/
    public const int GrassApartment = 51;
    public const int WaterApartment = 52;
    public const int DirtApartment = 53;

    //positive or negatives (numbers are *-1.0f when negative)
    public static float GetAdjacencyBonusModifier(int id) 
    {
        switch (id)
        {
            //nothing
            case NoBuilding: return 0.0f;
            case Grass: return 0.0f;
            case Dirt: return 0.0f;
            case Water: return 0.0f;

            //food
            case GrassFarm:  
            case WaterFarm: return 0.01f;

            //water conservation
            case WaterConservation: return .05f;

            //energy
            case WaterEnergy: 
            case DirtEnergy: return 0.02f;

            //happiness
            case DirtPark:
            case GrassPark: return .02f;
            case GrassApartment:
            case DirtApartment:
            case WaterApartment: return 0.02f;
            //count
            case SpacePort: return 0.0f;

            default:
                throw new System.Exception(string.Format("Invalid Id: {0}", id));
        }



    }

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
            case DirtPark:
            case GrassPark: return .02f;
            case GrassApartment:
            case DirtApartment:
            case WaterApartment: return 1.0f;
            //count
            case SpacePort: return 1.0f;

            default:
                throw new System.Exception(string.Format("Invalid Id: {0}", id));

        }
    }

    public static int GetBuildCost(int id)
    {
        switch (id)
        {
            case NoBuilding: return 10;

            case GrassFarm: return 5;

            case WaterConservation: return 20;
            case WaterEnergy: return 5;
            case WaterFarm: return 4;

            case DirtEnergy: return 10;

            case GrassPark:
            case DirtPark:
                return 5;
            case GrassApartment:
            case DirtApartment:
            case WaterApartment: return 5;
            case SpacePort: return 1000;

            default:
                throw new System.Exception(string.Format("Invalid Id: {0}", id));

        }

    }
    
    //tooltop generation or debug
    public static string ToString(int id, bool includeToolTip = false)
    {
        var append = string.Format("\nCost: {0} Energy", GetBuildCost(id));
        var formatString = string.Empty;
        var description = string.Empty;
        switch (id)
        {

            case NoBuilding:
                formatString = includeToolTip ? "Remove Building {0}" : "Grass{0}";
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

            case GrassPark:
            case DirtPark:
                formatString = "Parks & Recreation{0}";
                description = string.Format("\nIncrease Happiness by {0} per turn", GetBaseResourcePerRound(GrassPark));
                break;
            case DirtApartment:
            case GrassApartment:
            case WaterApartment:
                formatString = "Dwelling{0}";
                description = string.Format("\nIncrease Happiness by {0} per turn", GetBaseResourcePerRound(GrassApartment));
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

    public static List<int> GetIdOptionList()
    {
        //this will determine the order options appear
        return new List<int> {
            GrassApartment, GrassPark,  GrassFarm,
            DirtApartment, DirtPark,  DirtEnergy,
            WaterApartment, WaterEnergy, WaterFarm, WaterConservation,
            SpacePort, NoBuilding };
    }

};