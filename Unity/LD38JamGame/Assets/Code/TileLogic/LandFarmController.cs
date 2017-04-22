﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandFarmController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("Land Farm Created");
    }

    void Update()
    {

    }

    private float CalculateFoodProduced()
    {

        return 10.0f;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}