using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public GameObject shopPanel;
    private int currentSelectedItem;
    private int currentSelectedItemCost;
    private Player player;
    [SerializeField] public int itemCost0;
    [SerializeField] public int itemCost1;
    [SerializeField] public int itemCost2;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player!=null)
            {
                UIManager.Instance.OpenShop(player.diamonds, itemCost0, itemCost1, itemCost2);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = flamesword
        //1 = boots
        //2 = key
        currentSelectedItem = item;
        Debug.Log("Select Item " + item.ToString());
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(116);
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(0);
                break;

            case 2:
                UIManager.Instance.UpdateShopSelection(-110);
                break;
        }

    }

    public void BuyItem()
    {
        //get selection
        //get cost
        
        switch (currentSelectedItem)

        {
            case 0:
                currentSelectedItemCost = itemCost0;
                break;
            case 1:
                currentSelectedItemCost = itemCost1;
                break;

            case 2:
               currentSelectedItemCost = itemCost2;
                break;
        }


    //check if player diamonds >= cost
    if (player.diamonds>=currentSelectedItemCost)
        {
            //award item to player
            Debug.Log("player bought item" + currentSelectedItem.ToString());
            player.diamonds = player.diamonds - currentSelectedItemCost;
            //refresh UI gemcount
            UIManager.Instance.OpenShop(player.diamonds, itemCost0, itemCost1, itemCost2);
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
        }
 
    else
        {
            return;
        }

    }
}
