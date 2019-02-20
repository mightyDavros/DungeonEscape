using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
        pickupEmitter.numPickups = gems;
    }
    public void Damage()
    {
        //Debug.Log("Damaged!");
        if (isDead)
        {
            return;
        }
        Health--;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            animator.SetTrigger("Death");
            pickupEmitter.isEmitting = true;
            isDead = true;
        }
    }
}
