using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkController : BasicBuilding
{

    public override void OnStart()
    {
        Debug.Log("Park Created");
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Recreational");
    }

    void Update()
    {

    }

    public override void EndTurn()
    {

    }

}
