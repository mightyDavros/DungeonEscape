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

    public Text playerGemCountText;
    public Image selectionImage;
    public Text item0CostText;
    public Text item1CostText;
    public Text item2CostText;
    public Text gemCountText; //hud


    public void OpenShop(int gemCount, int item0Cost, int item1Cost, int item2Cost)
    {
        playerGemCountText.text = (gemCount.ToString() + "G");
        item0CostText.text = item0Cost.ToString();
        item1CostText.text = item1Cost.ToString();
        item2CostText.text = item2Cost.ToString();
    }
        
    public void UpdateShopSelection(int yPos)
    { 
        selectionImage.rectTransform.anchoredPosition = new Vector2 (selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = count.ToString();
    }

}
