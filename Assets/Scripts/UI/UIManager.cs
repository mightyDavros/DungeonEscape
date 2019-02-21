using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Text playerGemCountText;
    public Image selectionImage;


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


    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = (gemCount.ToString() + "G"); 
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateShopSelection(int yPos)
    { 
        selectionImage.rectTransform.anchoredPosition = new Vector2 (selectionImage.rectTransform.anchoredPosition.x, yPos);

    }
}
