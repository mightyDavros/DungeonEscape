using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit " + collision.gameObject.name);
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            //TODO increment player score
            player.AddGems(1);
            Destroy(gameObject);
        }
    }
}
