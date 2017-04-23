using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWater : BasicBuilding
{

    public override void OnStart()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.WaterEnergy];
    }

    // Update is called once per frame
    void Update () {
		
	}

    public float CalculateEnergy()
    {
        //check neighbors/negatives
        //bonuses etc..


        return 1.0f;
    }
    public override void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
        
    }

}
