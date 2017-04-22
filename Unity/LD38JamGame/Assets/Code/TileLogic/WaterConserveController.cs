using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConserveController : MonoBehaviour, ITurnInterface
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
    void Update()
    {

    }


    public void EndTurn()
    {

    }
}
