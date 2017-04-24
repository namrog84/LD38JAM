using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : BasicBuilding
{

    public override void OnStart()
    {
       
    }

    void Update()
    {

    }

    public override void EndTurn()
    {
        GameGod.Instance.currentSpaceShips++;
    }
}
