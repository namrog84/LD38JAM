using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIResource : MonoBehaviour
{


    private Text _UItextComponent;
    public int Id;
    public string Field;
    public string Value;
    public bool IsPercentage = false;
	// Use this for initialization
	void Awake () {
        _UItextComponent = gameObject.GetComponent<Text>();
        SetText(Value);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(string val)
    { 
        if (_UItextComponent == null) throw new System.Exception(string.Format("UIStatus>SetText: Failed null check on Id:{0}", Id));
        Value = val;
        _UItextComponent.text = string.Format("{0}: {1}{2}", Field.ToUpper(), Value, IsPercentage?"%":string.Empty);
    }

}
