using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : BasicBuilding
{

    public override void OnStart()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.Apartment];

    }

    void Update()
    {

    }

    public float CalculatePopulationGrowth()
    {
        //check neighbors/negatives
        //bonuses etc..
        return 1.0f;
    }

    public float CalculateHouseHappiness()
    {
        //check neighbors/negatives
        //bonuses etc..
        return 0.01f;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentPopulation += CalculatePopulationGrowth();

        GameGod.Instance.currentHappiness += CalculateHouseHappiness();

    }
}
