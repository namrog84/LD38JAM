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
        var _adjacency = GameGod.Instance.GetAdjacencyTiles(_id);
        var _modifier = 1.0f;
        foreach (var tile in _adjacency)
        {
            if (tile.BuildType == TileType.GrassFarm || tile.BuildType == TileType.WaterFarm)
            {
                _modifier += TileType.GetAdjacencyBonusModifier(TileType.GrassApartment);
            }
        }
        return TileType.GetBaseResourcePerRound(TileType.GrassApartment) * _modifier;
    }

    public float CalculateHouseHappiness()
    {
        var _adjacency = GameGod.Instance.GetAdjacencyTiles(_id);
        var _modifier = 1.0f;
        foreach (var tile in _adjacency)
        {
            if (tile.BuildType == TileType.DirtPark || tile.BuildType == TileType.GrassPark)
            {
                _modifier += TileType.GetAdjacencyBonusModifier(TileType.GrassApartment);
            }
            if (tile.BuildType == TileType.DirtEnergy)
            {
                _modifier += TileType.GetAdjacencyBonusModifier(TileType.DirtEnergy) * -1.0f;
            }
        }
        return TileType.GetBaseResourcePerRound(TileType.GrassApartment) * _modifier;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentPopulation += CalculatePopulationGrowth();

        GameGod.Instance.currentHappiness += CalculateHouseHappiness();

    }
}
