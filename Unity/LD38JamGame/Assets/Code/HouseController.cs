using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour, ITurnInterface
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public float CalculatePopulationGrowth()
    {
        //check neighbors/negatives
        //bonuses etc..
        return 1.0f;
    }

    public float CalculateHouseHappiness()
    {
        //check neighbors/negatives
        //bonuses etc..
        return 0.01f;
    }

    public void EndTurn()
    {
        GameGod.Instance.currentPopulation += CalculatePopulationGrowth();

        GameGod.Instance.currentHappiness += CalculateHouseHappiness();

    }
}
