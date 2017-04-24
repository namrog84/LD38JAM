using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWater : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[6]);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public float CalculateEnergy()
    {
        var _adjacency = GameGod.Instance.GetAdjacencyTiles(_id);
        var _modifier = 1.0f;
        foreach (var tile in _adjacency)
        {
            if (tile.BuildType == TileType.WaterEnergy || tile.BuildType == TileType.DirtEnergy)
            {
                _modifier += TileType.GetAdjacencyBonusModifier(TileType.DirtEnergy);
            }
        }
        return TileType.GetBaseResourcePerRound(TileType.WaterEnergy) * _modifier;
    }
    public override void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
        
    }

}
