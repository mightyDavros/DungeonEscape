using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int height;
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
            isDead = true;
            pickupEmitter.isEmitting = true;
        }


    }









}
