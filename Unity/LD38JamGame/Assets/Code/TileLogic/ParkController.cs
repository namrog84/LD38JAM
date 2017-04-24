using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkController : BasicBuilding
{

    public override void OnStart()
    {
        
    }

    void Update()
    {

    }
    public float CalculateHappiness()
    {
        //check neighbors/negatives
        //bonuses etc..


        return TileType.GetBaseResourcePerRound(TileType.DirtPark);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentHappiness += CalculateHappiness();
    }

}
