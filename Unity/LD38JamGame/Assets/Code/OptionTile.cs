using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionTile : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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
        UIResourceManager.CostToolTipObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIResourceManager.CostToolTipObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var tooltip = UIResourceManager.CostToolTipObject;
        var position = transform.position + new Vector3(0, 50, 0);
        position.x = Mathf.Clamp(position.x, 101.0f, 678.0f);
        if (position.y >= 561.0f)
        {
            position.y = 501.0f;
        }
        //position.y = Mathf.Clamp(position.y, 250, -250);
        tooltip.transform.position = position;
        tooltip.transform.GetChild(0).gameObject.GetComponent<Text>().text = TileType.ToString(BuildType, true);
        tooltip.SetActive(true);
    }
}
