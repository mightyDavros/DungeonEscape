using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEmitter : MonoBehaviour
{
    [SerializeField] GameObject emitterObject;
    private Rigidbody2D rigidbody;
    public Vector2 force;
    private Enemy enemy;
    public int numPickups = 0;
    private GameObject newPickup;
    private GameObject oldPickup;
    public bool isEmitting = false;



    private void Update()
    {
        if (isEmitting)
        {
            while (numPickups > 0)
            {
                EmitPickup();
                numPickups--;
            }
            if (numPickups == 0)
            {
                isEmitting = false;
            }
        }
    }
       

    private void EmitPickup()
    {
        //Debug.Log("Emitting...");
        if (newPickup != null)
        {
            oldPickup = newPickup;
        }
        newPickup = Instantiate(emitterObject, transform.position, Quaternion.identity);
        //Debug.Log("created " + newPickup.name);
        rigidbody = newPickup.GetComponent<Rigidbody2D>();
        if (oldPickup != null)
        {
            Physics2D.IgnoreCollision(oldPickup.GetComponent<Collider2D>(), newPickup.GetComponent<Collider2D>());
        }

        force = new Vector2(UnityEngine.Random.Range(-force.x, force.x), UnityEngine.Random.Range(force.y, force.y + 20));
        rigidbody.AddForce(force);

        //TODO create a list and populate as each pickup is created
 
    }
}
