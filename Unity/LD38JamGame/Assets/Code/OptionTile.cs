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

    public void OnPointerDown(PointerEventData eventData)
    {
        GameGod.Instance.OptionClicked(BuildType);
    }
}
