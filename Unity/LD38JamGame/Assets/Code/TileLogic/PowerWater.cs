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
        //check neighbors/negatives
        //bonuses etc..


        return TileType.GetBaseResourcePerRound(TileType.WaterEnergy);
    }
    public override void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
        
    }

}
