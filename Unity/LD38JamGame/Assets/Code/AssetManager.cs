using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour {

    public static Dictionary<int, Sprite> SpriteMap;


    private void Awake()
    {
        SpriteMap = new Dictionary<int, Sprite>()
        {
        {   TileType.Apartment, Resources.Load<Sprite>("Art/houseWater")   },
        {   TileType.GrassFarm, Resources.Load<Sprite>("Art/grassfarm")   },
        {   TileType.SpacePort, Resources.Load<Sprite>("Art/LaunchStation")   },
        {   TileType.RecreationPark, Resources.Load<Sprite>("Art/Recreational")   },
        {   TileType.DirtEnergy, Resources.Load<Sprite>("Art/powerLand2")   },

        {   TileType.WaterFarm, Resources.Load<Sprite>("Art/fishfarm5")   },
        {   TileType.WaterConservation, Resources.Load<Sprite>("Art/RecycleWater")   },
        {   TileType.WaterEnergy, Resources.Load<Sprite>("Art/powerWater2")   },

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
