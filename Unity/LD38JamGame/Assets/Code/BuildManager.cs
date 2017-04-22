using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour {


    public List<GameObject> OptionObjects = new List<GameObject>();
    // Use this for initialization
    void Start() {

        var _buildingIds = new List<int>()
        {
            TileType.DirtEnergy, TileType.GrassFarm, TileType.Apartment,
            TileType.WaterFarm, TileType.RecreationPark, TileType.SpacePort,
            TileType.WaterEnergy, TileType.WaterFarm, TileType.WaterConservation,
            TileType.Water, TileType.Grass, TileType.Dirt, 
        };
        var i = 0;
        foreach (Transform child in transform)
        {
            OptionObjects.Add(child.gameObject);
            child.gameObject.GetComponent<OptionTile>().BuildType = _buildingIds[i++];
        }
        GameGod.Instance._buildSystem = gameObject;
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MoveBuildSystem(GameObject obj)
    {
        var position = Camera.main.WorldToScreenPoint(obj.transform.position + new Vector3(0,4,0));
        gameObject.GetComponent<RectTransform>().position = position;
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
       foreach(var obj in OptionObjects)
        {

            var type = obj.GetComponent<OptionTile>().BuildType;
            if (buildOptions.Contains(type)) obj.SetActive(true);
            else obj.SetActive(false);                

        }
    }
}
