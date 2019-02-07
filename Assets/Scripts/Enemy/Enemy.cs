using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;

    protected Transform currentTarget;
    protected Animator animator;

    protected SpriteRenderer spriteRenderer;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();  
        currentTarget = pointB;
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }

    public virtual void Movement() // virtual means derived classes can optionally use this method
    {
        FlipSprite();


        if (Vector3.Distance(transform.position, pointA.position) <= 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointB");
            currentTarget = pointB;
        }
        else if (Vector3.Distance(transform.position, pointB.position) <= 0.01f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointA");
            currentTarget = pointA;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);        
    }


    public virtual void FlipSprite()
    {
        if (currentTarget == pointA)
        {
            spriteRenderer.flipX = true;
        }
        else 
        {
            spriteRenderer.flipX = false;
        }
    }

    //public abstract void Update(); //abstact means this is compulsory for all the classes that derive from this one








}
