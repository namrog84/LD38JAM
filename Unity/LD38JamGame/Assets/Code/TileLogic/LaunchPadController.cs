using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadController : MonoBehaviour, ITurnInterface
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
        // if > X Y Z
        // BLAST OFF!
    }

    public void BlastOff()
    {

    }
}
