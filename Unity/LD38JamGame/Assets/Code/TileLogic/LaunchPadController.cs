using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : BasicBuilding
{

    public override void OnStart()
    {
        GameGod.Instance.PlaySound(AssetManager.AudioMap[0]);
    }

    void Update()
    {

    }

    public override void EndTurn()
    {
        GameGod.Instance.currentSpaceShips++;
    }
}
