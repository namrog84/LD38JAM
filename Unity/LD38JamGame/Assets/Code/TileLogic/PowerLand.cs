﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLandController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("Power Land Created");
    }

    public float CalculateEnergy()
    {
        //check neighbors/negatives
        //bonuses etc..
        return 2.0f;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
    }

}
