using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


    public List<GameObject> OptionObjects = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
        foreach (Transform child in transform)
        {
            OptionObjects.Add(child.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MoveBuildSystem(GameObject obj)
    {
        gameObject.transform.position = obj.transform.position - new Vector3(0, -5f, obj.transform.position.z);
        gameObject.SetActive(true);
    }
    public void SetBuildOptions(int terrain, int build)
    {
        var buildOptions = new List<int>();
        switch (terrain)
        {
            /*this will configure based on our game rules*/
            case TileType.Grass:
                if (build == TileType.NoBuilding)
                {
                    buildOptions.AddRange(new int[4] { TileType.GrassFarm, TileType.RecreationPark, TileType.Apartment, TileType.SpacePort });
                }
                Debug.Log("Grass");
                break;
            case TileType.Water:
                if (build == TileType.NoBuilding)
                {
                    buildOptions.AddRange(new int[4] { TileType.WaterFarm, TileType.WaterConservation, TileType.Apartment, TileType.WaterEnergy });
                }
                Debug.Log("Water");
                break;
            case TileType.Dirt:
                if (build == TileType.NoBuilding)
                {
                    buildOptions.AddRange(new int[4] { TileType.DirtEnergy, TileType.RecreationPark, TileType.Apartment, TileType.SpacePort });
                }
                Debug.Log("Dirt");
                break;
            default:
                Debug.LogError("BuildManager>SetBuildOptions: Invalid Id");
                break;
        }
        UpdateOptions(buildOptions);    
    }
    public void UpdateOptions(List<int> buildOptions)
    {
        for (var i = 0; i < buildOptions.Count; i++) 
        {
            OptionObjects[i].GetComponent<OptionTile>().SetOption(buildOptions[i]);
        }
    }
}
