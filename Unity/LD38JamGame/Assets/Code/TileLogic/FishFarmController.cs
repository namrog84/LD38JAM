using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFarmController : BasicBuilding
{
    public override void OnStart()
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.WaterFarm];
    }

    private float CalculateFoodProduced()
    {
        return 5.0f;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}

