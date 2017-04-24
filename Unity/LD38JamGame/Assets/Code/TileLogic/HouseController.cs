using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[4], 0.75f);
    }

    void Update()
    {

    }

    public float CalculatePopulationGrowth()
    {
        //check neighbors/negatives
        //bonuses etc..
        return TileType.GetBaseResourcePerRound(TileType.GrassApartment);
    }

    public float CalculateHouseHappiness()
    {
        //check neighbors/negatives
        //bonuses etc..
        return TileType.GetBaseResourcePerRound(TileType.GrassApartment);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentPopulation += CalculatePopulationGrowth();

        GameGod.Instance.currentHappiness += CalculateHouseHappiness();

    }
}
