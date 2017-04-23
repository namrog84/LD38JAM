using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConserveController : BasicBuilding
{

    public override void OnStart()
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.WaterConservation];
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void EndTurn()
    {

    }
}
