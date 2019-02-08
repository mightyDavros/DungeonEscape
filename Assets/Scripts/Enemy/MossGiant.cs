using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int height;
    public int Health { get; set; }

    public void Damage()
    {

    }

    public override void Init()
    {
        base.Init();
        height = 5;
        Health = base.health;
    }







}
