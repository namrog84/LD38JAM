﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConserveController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("Water Conserve Created");
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/WaterRecycle");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void EndTurn()
    {

    }
}
