using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionTile : MonoBehaviour, IPointerDownHandler
{

    public int BuildType = TileType.NoBuilding;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetTile()
    {
        
        //set prefab to this
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(BuildType);
    }
}
