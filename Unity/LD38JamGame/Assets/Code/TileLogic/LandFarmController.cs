using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandFarmController : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[5]);
    }

    void Update()
    {

    }

    private float CalculateFoodProduced()
    {

        return TileType.GetBaseResourcePerRound(TileType.GrassFarm);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}
