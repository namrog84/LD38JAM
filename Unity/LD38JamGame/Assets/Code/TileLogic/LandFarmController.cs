using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandFarmController : BasicBuilding
{

    public override void OnStart()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.GrassFarm];
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
