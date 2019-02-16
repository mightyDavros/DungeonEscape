using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to spider
    Spider spider;

    private void Start()
    {
        //assign handle to spider
        spider = gameObject.GetComponentInParent<Spider>();
        Debug.Log("Found spider parent: " + spider.name);
    }
    public void Fire()
    {
        //tell spider to fire
        spider.Attack();
        //Debug.Log("Spider should fire!");
    }
}
