using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour {

    public static Dictionary<int, Sprite> SpriteMap;


    private void Awake()
    {
        SpriteMap = new Dictionary<int, Sprite>()
        {
            {    TileType.NoBuilding, Resources.Load<Sprite>("Art/redX") },
        {   TileType.WaterApartment, Resources.Load<Sprite>("Art/houseWater")   },
          {   TileType.DirtApartment, Resources.Load<Sprite>("Art/deserthouse")   },
            {   TileType.GrassApartment, Resources.Load<Sprite>("Art/grasshouse")   },
        {   TileType.WaterFarm, Resources.Load<Sprite>("Art/fishfarm5")   },
        {   TileType.GrassFarm, Resources.Load<Sprite>("Art/greenFarm")   },
        {   TileType.SpacePort, Resources.Load<Sprite>("Art/launchpad")   },
        {   TileType.GrassPark, Resources.Load<Sprite>("Art/greenRecreational")   },
          {   TileType.DirtPark, Resources.Load<Sprite>("Art/DirtPark")   },
        {   TileType.DirtEnergy, Resources.Load<Sprite>("Art/powerLand3")   },
        {   TileType.WaterConservation, Resources.Load<Sprite>("Art/recycleWater")   },
        {   TileType.WaterEnergy, Resources.Load<Sprite>("Art/powerWater2")   },
        // TileType.WaterApartment
        {   TileType.Water, Resources.Load<Sprite>("Art/testWater")   },
        {   TileType.Dirt, Resources.Load<Sprite>("Art/TestDirt")   },
        {   TileType.Grass, Resources.Load<Sprite>("Art/TestGrass")   },
        };
    }

    // Use this for initialization
    void Start () {
        
   
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
