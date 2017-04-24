using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class BasicBuilding : MonoBehaviour, ITurnInterface
{
    protected int _id;
    public void Start()
    {
        _id = gameObject.GetComponent<BuildTile>().TileId;
        GameGod.Instance.TurnTickables.Add(this);
        OnStart();
    }

    public void RemoveThis()
    {
        GameGod.Instance.TurnTickables.Remove(this);
    }

    public virtual void OnStart() { }

    public virtual void EndTurn() { }

}
