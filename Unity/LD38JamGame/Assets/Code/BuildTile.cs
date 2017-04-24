using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuildTile : MonoBehaviour, IPointerDownHandler
{

    public int TerrainType;
    public int BuildType;
    public int TileId;

    public BasicBuilding building;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeObject(int type, int id)
    {
        //Debug.Log(string.Format("The type is {0} with id = {1}", type, id));
        TerrainType = type;
        TileId = id;
        BuildType = TileType.NoBuilding;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameGod.Instance.TileClicked(TileId);
        }
    }
    public void PropogatedClick()
    {
        GameGod.Instance.TileClicked(TileId);
    }

    public void AddBuilding(int buildtype)
    {
       
        var tempExist = gameObject.GetComponent<BasicBuilding>();
       
        if (tempExist != null)
        {
            tempExist.RemoveThis();
            DestroyImmediate(gameObject.GetComponent<BasicBuilding>());
        }

        var renderer = gameObject.GetComponent<SpriteRenderer>();
        BuildType = buildtype;
        switch (buildtype)
        {
            case TileType.WaterApartment:
                building = gameObject.AddComponent<HouseController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.WaterApartment];
                break;
            case TileType.GrassApartment:
                building = gameObject.AddComponent<HouseController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.GrassApartment];
                break;
            case TileType.DirtApartment:
                building = gameObject.AddComponent<HouseController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.DirtApartment];
                break;
            case TileType.GrassPark:
                building = gameObject.AddComponent<ParkController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.GrassPark];
                break;
            case TileType.DirtPark:
                building = gameObject.AddComponent<ParkController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.DirtPark];
                break;
            case TileType.WaterFarm:
                building = gameObject.AddComponent<FishFarmController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.WaterFarm];
                break;
            case TileType.GrassFarm:
                building = gameObject.AddComponent<LandFarmController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.GrassFarm];
                break;
            case TileType.WaterConservation:
                building = gameObject.AddComponent<WaterConserveController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.WaterConservation];
                break;
            case TileType.DirtEnergy:
                building = gameObject.AddComponent<PowerLandController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.DirtEnergy];
                break;
            case TileType.WaterEnergy:
                building = gameObject.AddComponent<PowerWater>();
                renderer.sprite = AssetManager.SpriteMap[TileType.WaterEnergy];
                break;
            case TileType.SpacePort:
                building = gameObject.AddComponent<LaunchPadController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.SpacePort];
                break;
            case TileType.NoBuilding:
                BuildType = TileType.NoBuilding;
                building = null;
                renderer.sprite = AssetManager.SpriteMap[TerrainType];
                break;
            default:
                throw new System.Exception("BuildTile>AddBuilding>Incorrect Building Type");
        }
       

    }



}

