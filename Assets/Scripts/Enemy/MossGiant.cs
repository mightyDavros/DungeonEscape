using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Transform currentTarget = null;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        currentTarget = pointA;
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointA");
            currentTarget = pointA;
        }
        else if (Vector3.Distance(transform.position, pointA.position) < 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointB");
            currentTarget = pointB;
        }
    }

    private void FlipSprite()
    {
        if (currentTarget == pointB)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }


}
