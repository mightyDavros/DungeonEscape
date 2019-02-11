using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;

    protected Transform currentTarget;
    protected Animator animator;

    protected SpriteRenderer spriteRenderer;

    protected bool isHit = false;
    protected Player player;
    [SerializeField] protected float combatDistance = 2.0f;


    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();  
        currentTarget = pointB;
        //players = GameObject.FindGameObjectsWithTag("Player");
        player = GameObject.FindObjectOfType<Player>();
        Debug.Log("Player found: " + player.name);
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("InCombat") == false)
        {
            return;
        }
        else
        {
            Movement();
        }
    }

    public virtual void Movement() // virtual means derived classes can optionally use this method
    {
        CheckPlayerDistance();
        FlipSprite();        

        if (Vector3.Distance(transform.position, pointA.position) <= 0.001f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointB");
            currentTarget = pointB;
        }
        else if (Vector3.Distance(transform.position, pointB.position) <= 0.001f)
        {
            animator.SetTrigger("Idle");
            //Debug.Log("Change Target to pointA");
            currentTarget = pointA;
        }
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }
    }

    private void CheckPlayerDistance()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distance between player and " + gameObject.name + " = " + distToPlayer.ToString());

        if (distToPlayer > combatDistance)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }
    }

    public virtual void FlipSprite()
    {
        if (animator.GetBool("InCombat"))
        {
            //face player
            Vector3 direction = player.transform.localPosition - transform.localPosition;
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else 
        {
            //face waypoint
            if (currentTarget == pointA)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
           
    }

    //public abstract void Update(); //abstact means this is compulsory for all the classes that derive from this one

}
