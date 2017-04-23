using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFarmController : BasicBuilding
{
    public override void OnStart()
    {
        Debug.Log("FishFarm Created");
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/fishfarm");
    }

    private float CalculateFoodProduced()
    {
        return 5.0f;
    }

    public override void EndTurn()
    {
        GameGod.Instance.currentFood += CalculateFoodProduced();

    }
}

