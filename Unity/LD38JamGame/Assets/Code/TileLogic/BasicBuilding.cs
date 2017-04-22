using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class BasicBuilding : MonoBehaviour, ITurnInterface
{

    public void Start()
    {
        GameGod.Instance.TurnTickables.Add(this);
    }

    public void RemoveThis()
    {
        GameGod.Instance.TurnTickables.Remove(this);
    }

    public virtual void OnStart() { }

    public virtual void EndTurn() { }

}
