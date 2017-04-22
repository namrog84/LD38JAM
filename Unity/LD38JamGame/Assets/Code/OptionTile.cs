using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTile : MonoBehaviour {

    public int BuildType = TileType.NoBuilding;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetOption(int t)
    {
        BuildType = t;
        //set prefab to this
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameGod.OptionClicked(BuildType);
        }
    }
}
