using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFarmController : BasicBuilding
{
    public override void OnStart()
    {

       
    }

    private float CalculateFoodProduced()
    {
        return TileType.GetBaseResourcePerRound(TileType.WaterFarm);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}

