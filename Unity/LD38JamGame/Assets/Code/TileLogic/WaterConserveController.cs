﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConserveController : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[7]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void EndTurn()
    {
        GameGod.Instance.currentConservationFacilities++;
    }
}
