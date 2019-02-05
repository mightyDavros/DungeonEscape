using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Transform target;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        target = pointB;
        animator = gameObject.GetComponentInChildren<Animator>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }


    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }  
        MoveToTarget();        
    }

    private void MoveToTarget()
    {
        FlipSprite();
        if (Vector3.Distance(transform.position, pointA.position) <= 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointB");
            target = pointB;
        }
        else if (Vector3.Distance(transform.position, pointB.position) <= 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointA");
            target = pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void FlipSprite()
    {
        if (target == pointA)
        {
            sprite.flipX = true;
        }
        else 
        {
            sprite.flipX = false;
        }
    }
}
