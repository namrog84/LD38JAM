using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFarmController : BasicBuilding
{
    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[5]);
    }

    private float CalculateFoodProduced()
    {
        var _adjacency = GameGod.Instance.GetAdjacencyTiles(_id);
        var _modifier = 1.0f;
        foreach (var tile in _adjacency)
        {
            if (tile.BuildType == TileType.GrassFarm || tile.BuildType == TileType.WaterFarm)
            {
                _modifier += TileType.GetAdjacencyBonusModifier(TileType.WaterFarm);
            }
        }
        return TileType.GetBaseResourcePerRound(TileType.WaterFarm) * _modifier;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}

