using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : BasicBuilding
{

    public override void OnStart()
    {
      

    }

    void Update()
    {

    }

    public float CalculatePopulationGrowth()
    {
        //check neighbors/negatives
        //bonuses etc..
        return TileType.GetBaseResourcePerRound(TileType.Apartment);
    }

    public float CalculateHouseHappiness()
    {
        //check neighbors/negatives
        //bonuses etc..
        return TileType.GetBaseResourcePerRound(TileType.Apartment);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentPopulation += CalculatePopulationGrowth();

        GameGod.Instance.currentHappiness += CalculateHouseHappiness();

    }
}
