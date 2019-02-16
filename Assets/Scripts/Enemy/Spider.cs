using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileLocator;

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage()
    {
        //Debug.Log("Damaged!");
        Health--;
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }

    public override void Movement()
    {
        //sit still
    }

    public override void Update()
    {
        //removed movement call and Incombat error
    }

    public void Attack()
    {
        //instantiate the acid effect 
        
        Instantiate(projectile, projectileLocator.position, Quaternion.identity);
        Debug.Log("Instantiating Acid effect!");
    }
}
