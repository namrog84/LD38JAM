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
        Instance.currentEnergy = 15;
        Instance.currentHappiness = .50f;
        Instance.currentFood = 10;
        Instance.currentTurn = Instance.turnsWithoutFood = Instance.turnsWithoutWater = Instance.currentConservationFacilities = Instance.currentSpaceShips = 0;
        Instance.currentPopulation = Instance.baseHappinessPerRound = 5;
        Instance.currentWaterModifier = 1;
        Instance.currentWaterRemaining = Instance.totalWorldWaterStart;
        _uiManager.GetComponent<UIResourceManager>().UpdateStatus();
        _canvasUI.SetActive(true);

    }
    private static GameObject _canvasUI;
    public List<TileInformation> GameBoard = new List<TileInformation>();

    private int _currentFocusTile = -1;



    public float totalWorldWaterStart = 100;

    public float baseGrowthPerRound;
    public float baseHappinessPerRound;
    public float baseEnergyPerRound;

    public int currentTurn;
    public float currentEnergy;
    public float currentPopulation;
    public float currentHappiness;
    public float currentFood;
    public float currentWaterRemaining;
    public float currentWaterModifier;
    public int currentConservationFacilities;
    private int turnsWithoutFood = 0;
    private int turnsWithoutWater = 0;

    public int currentSpaceShips;


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
        bm.SetBuildOptions(bt.TerrainType, bt.BuildType);
        //Debug.LogFormat("Neighbors: {0}, {1}, {2}, {3}", tileInfo.NorthId, tileInfo.SouthId, tileInfo.WestId, tileInfo.EastId);
    }

    public void OptionClicked(int id)
    {
        //Debug.LogFormat("Building type selected: {0}, time to change tile {1}", TileType.ToString(id), CurrentFocusTile);
        var cost = TileType.GetBuildCost(id);
        if (currentEnergy >= cost)
        {
            currentEnergy -= cost;
            _uiManager.GetComponent<UIResourceManager>().UpdateStatus();
            GameBoard[_currentFocusTile].GroundTileObject.GetComponent<BuildTile>().AddBuilding(id);
            _buildSystem.SetActive(false);
            _currentFocusTile = -1;
        }
        else
        {
            Debug.LogFormat("Insufficient Funds> current energy: {0} || cost: {1}", currentEnergy, cost);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }


    Button endTurnButton;
    public void EndTurn()
    {
        isFading = true;
        if (endTurnButton == null)
        {
            var etb = GameObject.Find("EndTurnButton");
            endTurnButton = etb.GetComponent<Button>();
        }
        endTurnButton.interactable = false;



        StartCoroutine(FadeFunc());
        currentConservationFacilities = 0;
        currentSpaceShips = 0;
        //add tile bonuses
        foreach (var EndTurnObject in TurnTickables)
        {
            EndTurnObject.EndTurn();
        }
        //move turn
        currentTurn++;

        //energy restoration
        currentEnergy += baseEnergyPerRound;

        //water
        currentWaterRemaining -= (currentPopulation * .1f) * currentWaterModifier;
        if (currentWaterRemaining < 0)
        {
            currentWaterRemaining = 0;
            turnsWithoutWater++;
            if (turnsWithoutWater == 2) currentPopulation *= .50f;
            if (turnsWithoutWater == 4) currentPopulation = 0;
            currentHappiness -= Mathf.Pow(.15f, 1 + turnsWithoutWater);
        }
        Debug.LogFormat("water left {0}", currentWaterRemaining);

        //food
        currentFood -= currentPopulation;
        if (currentFood < 0)
        {
            currentFood = 0;
            turnsWithoutFood++;
            currentHappiness -= Mathf.Pow(.02f, 1 + turnsWithoutFood);
        }

        //overpopulation unhappiness
        currentHappiness -= currentPopulation - baseHappinessPerRound;
        if (currentHappiness <= 0) currentEnergy *= .85f;
        currentHappiness = Mathf.Clamp01(currentHappiness);

        //population increase
        currentPopulation += currentPopulation * Mathf.Clamp(currentHappiness, .3f, .6f);

        //Debug.LogFormat("{0} {1} {2} {3} {4}", currentFood, currentHappiness, currentPopulation, currentEnergy, currentTurn);
        _uiManager.GetComponent<UIResourceManager>().UpdateStatus();

        if (currentPopulation <= 0)
        {
            _canvasUI.SetActive(false);
            _buildSystem.SetActive(false);
            SceneManager.LoadScene("GameOverScene");
        }
    }



    public Texture2D fadeTexture;
    public bool isFading = false;
    private void OnGUI()
    {
        if (isFading)
        {
            var col = GUI.color;
            col.a = alpha;
            GUI.color = col;
            GUI.depth = -1000;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }

    private float alpha = 0.0f;
    private float fadeDir = 1;
    private float fadeSpeed = 1.4f;
    IEnumerator FadeFunc()
    {
        while (alpha < 1)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            yield return new WaitForEndOfFrame();
        }

        //call EndTurn Func
        yield return new WaitForEndOfFrame();


        while (alpha > 0)
        {
            alpha += -fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            yield return new WaitForEndOfFrame();
        }
        isFading = false;
        if (endTurnButton != null)
        {
            endTurnButton.interactable = true;
        }
        //yield return null;
    }

}

