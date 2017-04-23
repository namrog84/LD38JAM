using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceManager : MonoBehaviour {

    private UIResource _turnUIComponent;
    // Use this for initialization
    private void Awake()
    {
        _turnUIComponent = GameObject.Find("TurnCount").GetComponent<UIResource>();
    }
    void Start ()
    {
        GameGod.Instance.SetUIManager(gameObject);     
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateStatus()
    {
        _turnUIComponent.SetText(GameGod.Instance.currentTurn.ToString());
        foreach (Transform obj in transform)
        {
            var _uiComponent = obj.gameObject.GetComponent<UIResource>();
            switch (_uiComponent.Id)
            {
                case UIType.Energy:
                    _uiComponent.SetText(((int)GameGod.Instance.currentEnergy).ToString());
                    break;
                case UIType.Food:
                    _uiComponent.SetText(((int)GameGod.Instance.currentFood).ToString());
                    break;
                case UIType.Happy:       
                    //Debug.LogFormat("Current Happiness is {0} and {1} is the number", val, GameGod.Instance.currentHappiness);
                    _uiComponent.SetText(((int)(GameGod.Instance.currentHappiness * 100)).ToString());
                    break;
                case UIType.People:
                    _uiComponent.SetText(((int)GameGod.Instance.currentPopulation).ToString());
                    break;
                default:
                    throw new System.Exception("UIStatusManager>UpdateStatus: Invalid Id");

          }
            
        }
    }

}
