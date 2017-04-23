using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnPanelInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
    public void OnPointerDown(PointerEventData eventData)
    {
        var pos = Camera.main.ScreenToWorldPoint(eventData.pressPosition);
        pos.z = -2;
        var hit = Physics2D.Raycast(pos, Vector3.forward);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<BuildTile>().PropogatedClick();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //gameObject.GetComponent<Image>().CrossFadeColor(Color.black, .5f, false, true);
        gameObject.GetComponent<Image>().CrossFadeAlpha(0.3f, .3f, true);  

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().CrossFadeAlpha(1f, .3f, true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
