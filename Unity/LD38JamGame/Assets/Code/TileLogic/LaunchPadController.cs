using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("LaunchPad Created");
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
