﻿using System;
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

    public void AddBuilding(int buildtype)
    {
        var tempExist = gameObject.GetComponent<BasicBuilding>();
        if (tempExist != null)
        {
            DestroyImmediate(gameObject.GetComponent<BasicBuilding>());
        }

        BuildType = buildtype;
        switch (buildtype)
        {
            case TileType.Apartment:
                building = gameObject.AddComponent<HouseController>();
                break;
            case TileType.RecreationPark:
                building = gameObject.AddComponent<ParkController>();
                break;
            case TileType.WaterFarm:
                building = gameObject.AddComponent<FishFarmController>();
                break;
            case TileType.GrassFarm:
                building = gameObject.AddComponent<LandFarmController>();
                break;
            case TileType.WaterConservation:
                building = gameObject.AddComponent<WaterConserveController>();
                break;
            case TileType.DirtEnergy:
                building = gameObject.AddComponent<PowerLandController>();
                break;
            case TileType.WaterEnergy:
                building = gameObject.AddComponent<PowerWater>();
                break;
            case TileType.SpacePort:
                building = gameObject.AddComponent<LaunchPadController>();
                break;
            default:
                throw new System.Exception("BuildTile>AddBuilding>Incorrect Building Type");
        }

    }



}
