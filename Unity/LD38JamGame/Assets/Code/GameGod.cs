using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour
{
    // On the first day, GameGod is created.
    // Game god is never destroyed.

    // Store global variables here


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



    private static GameGod _instance = null;
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



    // Update is called once per frame
    void Update()
    {

    }
}
