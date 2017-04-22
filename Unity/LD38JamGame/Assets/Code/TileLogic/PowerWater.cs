﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWater : MonoBehaviour, ITurnInterface
{

    // Use this for initialization
    void Start()
    {
        GameGod.Instance.TurnTickables.Add(this);
    }
    private void RemoveThis()
    {
        GameGod.Instance.TurnTickables.Remove(this);
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
    public void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();
        
    }

}
