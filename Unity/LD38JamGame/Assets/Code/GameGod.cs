using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGod : MonoBehaviour
{
    // On the first day, GameGod is created.
    // Game god is never destroyed.

    // Store global variables here

    // ADAM TO DO
    // neighbor calculate better now with buildings.

    private static void SetNewGame()
    {
        Instance._currentFocusTile = -1;
        Instance.currentEnergy = 10;
        Instance.currentFood = Instance.currentHappiness = Instance.currentTurn = 0;
        Instance.currentPopulation = 0;
        Instance.currentWaterRemaining = Instance.totalWorldWaterStart;
        _uiManager.GetComponent<UIResourceManager>().UpdateStatus();
        _canvasUI.SetActive(true);

    }
    private static GameObject _canvasUI;
    public List<TileInformation> GameBoard = new List<TileInformation>();
  
    private int _currentFocusTile = -1;
    // Merp Derp Eneryg Power!
    public float currentEnergy;

    // Merp Derp Eneryg Power!
    public float currentFood;


    // N x 1000s of population?  (1 here means 1000 people?  or 1 million? I dunno)
    public float currentPopulation;

    // Percentage of 0 to 1 of population happiness
    public float currentHappiness;

    // Player's current turn
    public int currentTurn;

    // How much water is left for the planet
    public float currentWaterRemaining;

    // Total amount of water on planet
    public float totalWorldWaterStart = 100;

    
    public List<ITurnInterface> TurnTickables = new List<ITurnInterface>();

    private static GameObject _uiManager;
    public void SetUIManager(GameObject g)
    {
        if (_uiManager != null) return;
        _uiManager = g;
    }

    private static GameObject _buildSystem;
    public void SetBuildSystem(GameObject g)
    {
        if (_buildSystem != null) return;
        _buildSystem = g;
    }


    private static int referenceCount;
    private static GameGod _instance = null;
    public static GameGod Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameGod>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
       
    }

    private void Start()
    {
        referenceCount++;
        //only called on singleton
        if (referenceCount <= 1) _canvasUI = GameObject.Find("Canvas");
        SetNewGame();  //needed on every call but after the previous assignment  
        if (referenceCount > 1)
        {
            //there is only 1 GameGod! Destroy the heathens! 
            DestroyImmediate(this.gameObject);
            return;
        }
    }

    public void TileClicked(int id)
    {
        if (_currentFocusTile == id) return;

        _currentFocusTile = id;
        var obj = GameBoard[id].GroundTileObject;
        var bm = _buildSystem.GetComponent<BuildManager>();
        var bt = obj.GetComponent<BuildTile>();
        bm.MoveBuildSystem(obj);
        Debug.LogFormat("this is the buildingtype {0}", TileType.ToString(bt.BuildType));
        bm.SetBuildOptions(bt.TerrainType, bt.BuildType);
        //Debug.LogFormat("Neighbors: {0}, {1}, {2}, {3}", tileInfo.NorthId, tileInfo.SouthId, tileInfo.WestId, tileInfo.EastId);
    }

    public void OptionClicked(int id)
    {
        //Debug.LogFormat("Building type selected: {0}, time to change tile {1}", TileType.ToString(id), CurrentFocusTile);
        GameBoard[_currentFocusTile].GroundTileObject.GetComponent<BuildTile>().AddBuilding(id);
        _buildSystem.SetActive(false);
        _currentFocusTile = -1;
    }

    // Update is called once per frame
    void Update()
    {
  

    }


    public void EndTurn()
    {
        foreach(var EndTurnObject in TurnTickables)
        {
            EndTurnObject.EndTurn();
        }
        currentTurn++;
        //Debug.LogFormat("{0} {1} {2} {3} {4}", currentFood, currentHappiness, currentPopulation, currentEnergy, currentTurn);
        _uiManager.GetComponent<UIResourceManager>().UpdateStatus();

        if(currentPopulation <= 0)
        {
            _canvasUI.SetActive(false);
            _buildSystem.SetActive(false);
            SceneManager.LoadScene("GameOverScene");
        }
    }

}
