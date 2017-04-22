using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildTile : MonoBehaviour, IPointerDownHandler {

    public int TerrainType;
    public int BuildType;
    public int TileId;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeObject(int type, int id)
    {
        //Debug.Log(string.Format("The type is {0} with id = {1}", type, id));
        TerrainType = type;
        TileId = id;
        BuildType = TileType.NoBuilding;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameGod.Instance.TileClicked(TileId);
        }
    }
}
