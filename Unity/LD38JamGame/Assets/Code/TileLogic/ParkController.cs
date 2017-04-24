using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkController : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[3]);
    }

    void Update()
    {

    }
    public float CalculateHappiness()
    {
        return TileType.GetBaseResourcePerRound(TileType.DirtPark);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentHappiness += CalculateHappiness();
    }

}
