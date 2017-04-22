using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour
{
    // On the first day, GameGod is created.
    // Game god is never destroyed.

    // Store global variables here

    public List<TileInformation> GameBoard = new List<TileInformation>();
    private int CurrentFocusTile; 
    // Merp Derp Eneryg Power!
    public int currentEnergy;

    // N x 1000s of population?  (1 here means 1000 people?  or 1 million? I dunno)
    public int currentPopulation;

    // Percentage of 0 to 1 of population happiness
    public float currentHappiness;

    // Player's current turn
    public int currentTurn;
    
    // How much water is left for the planet
    public int currentWaterRemaining;

    // Total amount of water on planet
    public int totalWorldWaterStart = 150;

    public GameObject _buildSystem;

    private static GameGod _instance = null;
    private static int referenceCount;

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
        referenceCount++;
        if(referenceCount > 1)
        {
            //there is only 1 GameGod! Destroy the heathens! 
            DestroyImmediate(this.gameObject);
            return;
        }

        //_buildSystem.SetActive(true);
        //Debug.Log(_buildSystem);
    }


    public void InitializeTile(GameObject obj, int type)
    {
        obj.GetComponent<BuildTile>().InitializeObject(type, GameBoard.Count);
        GameBoard.Add(new TileInformation(obj));
    }

    public void TileClicked(int id)
    {
        if (CurrentFocusTile == id) return;
        CurrentFocusTile = id;
        var obj = GameBoard[id].GameObject;
        var bm = _buildSystem.GetComponent<BuildManager>();
        var bt = obj.GetComponent<BuildTile>();
        bm.MoveBuildSystem(obj);
        bm.SetBuildOptions(bt.TerrainType, bt.BuildType);
    }

    public void OptionClicked(int id)
    {
        Debug.Log(string.Format("Building type selected: {0}, time to change tile {1}", Utility.GetTileString(id), CurrentFocusTile));
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        
    }

}
