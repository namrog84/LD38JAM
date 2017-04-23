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
            DestroyImmediate(gameObject.GetComponent<BasicBuilding>());
        }

        var renderer = gameObject.GetComponent<SpriteRenderer>();
        BuildType = buildtype;
        switch (buildtype)
        {
            case TileType.Apartment:
                building = gameObject.AddComponent<HouseController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.Apartment];
                break;
            case TileType.RecreationPark:
                building = gameObject.AddComponent<ParkController>();
                renderer.sprite = AssetManager.SpriteMap[TileType.RecreationPark];
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
            case TileType.Dirt:
                BuildType = TileType.NoBuilding;
                renderer.sprite = AssetManager.SpriteMap[TileType.Dirt];
                break;
            case TileType.Grass:
                BuildType = TileType.NoBuilding;
                renderer.sprite = AssetManager.SpriteMap[TileType.Grass];
                break;
            case TileType.Water:
                BuildType = TileType.NoBuilding;
                renderer.sprite = AssetManager.SpriteMap[TileType.Water];
                break;
            default:
                throw new System.Exception("BuildTile>AddBuilding>Incorrect Building Type");
        }
       

    }



}

