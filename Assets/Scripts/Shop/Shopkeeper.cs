using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public GameObject shopPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player!=null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
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
}
