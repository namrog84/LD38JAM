using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour
{
    // On the first day, GameGod is created.
    // Game god is never destroyed.

    // Store global variables here

    public static List<TileInformation> GameBoard = new List<TileInformation>();
    private static int CurrentFocusTile; 
    // Merp Derp Eneryg Power!
    public static int currentEnergy;

    // N x 1000s of population?  (1 here means 1000 people?  or 1 million? I dunno)
    public static int currentPopulation;

    // Percentage of 0 to 1 of population happiness
    public static float currentHappiness;

    // Player's current turn
    public static int currentTurn;
    
    // How much water is left for the planet
    public static int currentWaterRemaining;

    // Total amount of water on planet
    public static int totalWorldWaterStart = 150;

    private static GameGod _instance = null;
    private static GameObject _buildSystem;
    public static GameGod Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameGod>();
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
        _buildSystem = GameObject.Find("BuildSystem");
        _buildSystem.SetActive(false);
        //_buildSystem.SetActive(true);
        //Debug.Log(_buildSystem);
    }
    public static void InitializeTile(GameObject obj, int type)
    {
        obj.GetComponent<BuildTile>().InitializeObject(type, GameBoard.Count);
        GameBoard.Add(new TileInformation(obj));
       
    }

    public static void TileClicked(int id)
    {
        CurrentFocusTile = id;
        var obj = GameBoard[id].GameObject;
        var bm = _buildSystem.GetComponent<BuildManager>();
        var bt = obj.GetComponent<BuildTile>();
        bm.MoveBuildSystem(obj);
        bm.SetBuildOptions(bt.TerrainType, bt.BuildType);
    }

    public static void OptionClicked(int id)
    {
        Debug.Log(string.Format("Building type selected: {0}, time to change tile {1}", Utility.GetTileString(id), CurrentFocusTile));
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        
    }

}
