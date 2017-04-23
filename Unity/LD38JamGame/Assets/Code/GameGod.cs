using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGod : MonoBehaviour
{
    // On the first day, GameGod is created.
    // Game god is never destroyed.

    // Store global variables here

    // ADAM TO DO
    // scene transition game/over
    // neighbor calculate better now with buildings.


    public List<TileInformation> GameBoard = new List<TileInformation>();
    public Dictionary<TileType, Sprite> SpriteMap;
    public Dictionary<string, int> test = new Dictionary<string, int>();
    private int CurrentFocusTile;
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
    public float totalWorldWaterStart = 150;

    
    public List<ITurnInterface> TurnTickables = new List<ITurnInterface>();

    private static GameObject _uiManager;
    public void SetUIManager(GameObject g)
    {
        _uiManager = g;
        _uiManager.GetComponent<UIStatusManager>().UpdateStatus();
    }

    private static GameObject _buildSystem;
    public void SetBuildSystem(GameObject g)
    {
        _buildSystem = g;
    }


    private static GameGod _instance = null;
    private static int referenceCount;







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
        if (referenceCount > 1)
        {
            //there is only 1 GameGod! Destroy the heathens! 
            DestroyImmediate(this.gameObject);
            return;
        }

        //_buildSystem.SetActive(true);
        //Debug.Log(_buildSystem);
    }

    public void TileClicked(int id)
    {
        if (CurrentFocusTile == id) return;

        CurrentFocusTile = id;
        var tileInfo = GameBoard[id];
        var obj = tileInfo.GroundTileObject;
        var bm = _buildSystem.GetComponent<BuildManager>();
        var bt = obj.GetComponent<BuildTile>();
        bm.MoveBuildSystem(obj);
        bm.SetBuildOptions(bt.TerrainType, bt.BuildType);
        Debug.LogFormat("Neighbors: {0}, {1}, {2}, {3}", tileInfo.NorthId, tileInfo.SouthId, tileInfo.WestId, tileInfo.EastId);
    }

    public void OptionClicked(int id)
    {
        Debug.LogFormat("Building type selected: {0}, time to change tile {1}", TileType.ToString(id), CurrentFocusTile);
        GameBoard[CurrentFocusTile].GroundTileObject.GetComponent<BuildTile>().AddBuilding(id);
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

        Debug.LogFormat("{0} {1} {2} {3} {4}", currentFood, currentHappiness, currentPopulation, currentEnergy, currentTurn);
        _uiManager.GetComponent<UIStatusManager>().UpdateStatus();

        if(currentPopulation <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

}
