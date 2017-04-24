using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLandController : BasicBuilding
{

    public override void OnStart()
    {
      
    }

    public float CalculateEnergy()
    {
        //check neighbors/negatives
        //bonuses etc..
        return TileType.GetBaseResourcePerRound(TileType.DirtEnergy);
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
    }

}
