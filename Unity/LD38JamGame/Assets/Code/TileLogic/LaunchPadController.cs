using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("LaunchPad Created");
        gameObject.GetComponent<SpriteRenderer>().sprite = AssetManager.SpriteMap[TileType.SpacePort];
    }

    void Update()
    {

    }

    public override void EndTurn()
    {
        // if > X Y Z
        // BLAST OFF!
    }

    public void BlastOff()
    {

    }
}
