using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
       
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is Null!");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public Text shopPlayerGemCountText;
    public Image selectionImage;
    public Text item0CostText;
    public Text item1CostText;
    public Text item2CostText;    
    public Text gemCountHUDText; //hud
    public Text gasLevelHUDText; //hud
    public Image[] lifebars;



    public void OpenShop(int gemCount, int item0Cost, int item1Cost, int item2Cost)
    {
        shopPlayerGemCountText.text = (gemCount.ToString() + "G");
        item0CostText.text = item0Cost.ToString();
        item1CostText.text = item1Cost.ToString();
        item2CostText.text = item2Cost.ToString();
    }
        
    public void UpdateShopSelection(int yPos)
    { 
        selectionImage.rectTransform.anchoredPosition = new Vector2 (selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateShopGemCount(int gemCount) //HUD Gem count
    {
        shopPlayerGemCountText.text = (gemCount.ToString() + "G");
    }

    public void UpdateHUDGemCount(int count) //HUD Gem count
    {
        gemCountHUDText.text = count.ToString();
    }

    public void UpdateHUDGasLevel(float gasLevel) //HUD Gem count
    {
       gasLevelHUDText.text = gasLevel.ToString();
    }

    public void UpdateLives(int livesRemaining)
    {
        //need a reference to the life bars so can deactivate them
        //reckons we use a for loop here?
        //int i;
        for (int i=0; i<=livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                Debug.Log("Lives remaining = " + livesRemaining.ToString() + ". turning off " + lifebars[i]);
                lifebars[i].enabled = false;
            }
        }
    }

}
