﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLand : MonoBehaviour, ITurnInterface
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public float CalculateEnergy()
    {
        //check neighbors/negatives
        //bonuses etc..


        return 2.0f;
    }
    public void EndTurn()
    {
        GameGod.Instance.currentEnergy += CalculateEnergy();

    }


}
