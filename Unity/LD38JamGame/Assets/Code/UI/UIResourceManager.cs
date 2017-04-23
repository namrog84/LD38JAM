using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIResourceManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        var pos = Camera.main.ScreenToWorldPoint(eventData.pressPosition);
        pos.z = -2;
        var hit = Physics2D.Raycast(pos, Vector3.forward);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<BuildTile>().PropogatedClick();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //gameObject.GetComponent<Image>().CrossFadeColor(Color.black, .5f, false, true);
        gameObject.GetComponent<Image>().CrossFadeAlpha(0.3f, .3f, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().CrossFadeAlpha(1f, .3f, true);
    }

    private UIResource _turnUIComponent;
    public static GameObject CostToolTipObject;
    // Use this for initialization
    private void Awake()
    {
        _turnUIComponent = GameObject.Find("TurnCount").GetComponent<UIResource>();
        CostToolTipObject = GameObject.Find("CostTooltip");
        CostToolTipObject.SetActive(false);
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
