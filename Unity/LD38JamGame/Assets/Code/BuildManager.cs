using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour {


    private List<GameObject> _options = new List<GameObject>();
    public GameObject _optionPrefab;
    // Use this for initialization
    void Start() {
 
        var _buildingIds = TileType.GetIdList();
        foreach (var id in _buildingIds)
        {
            var obj = Instantiate(_optionPrefab);
            obj.GetComponent<OptionTile>().BuildType = id;
            obj.GetComponent<RectTransform>().SetParent(gameObject.transform);
            obj.GetComponent<Image>().sprite = AssetManager.SpriteMap[id];
            _options.Add(obj);
        }
        GameGod.Instance.SetBuildSystem(gameObject);
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MoveBuildSystem(GameObject obj)
    {
        var position = Camera.main.WorldToScreenPoint(obj.transform.position + new Vector3(0,4,0));
        //var terrain = obj.GetComponent<BuildTile>().TerrainType;
        position.x =  Mathf.Clamp(position.x, 45, 730);
        position.y = Mathf.Clamp(position.y, 90, 570);
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
                else
                {
                    buildOptions.Add(TileType.Grass);
                }
                break;
            case TileType.Water:
                if (build == TileType.NoBuilding)
                {
                    buildOptions.AddRange(new int[4] { TileType.WaterFarm, TileType.WaterConservation, TileType.Apartment, TileType.WaterEnergy });
                }
                else
                {
                    buildOptions.Add(TileType.Water);
                }
                break;
            case TileType.Dirt:
                if (build == TileType.NoBuilding)
                {
                    buildOptions.AddRange(new int[4] { TileType.DirtEnergy, TileType.RecreationPark, TileType.Apartment, TileType.SpacePort });
                }   
                else
                {
                    buildOptions.Add(TileType.Dirt);
                }
                break;
            default:
                throw new System.Exception("BuildManager>SetBuildOptions: Invalid Id");
        }
        UpdateOptions(buildOptions);    
    }

    public void UpdateOptions(List<int> buildOptions)
    {

       foreach (var obj in _options)
       {
            var type = obj.GetComponent<OptionTile>().BuildType;
            if (buildOptions.Contains(type)) obj.SetActive(true);
            else obj.SetActive(false);
       }
    }
}
