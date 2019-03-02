using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigid;
    private Collider2D[] _colliders;
    [SerializeField] private float burpForce = 1f;
    [SerializeField] private float burpVerticalForce = 1f;
    [SerializeField] private float parpForce = 1f;
    [SerializeField] private float maxUpVelocity = 7f;

    [SerializeField] private float gasRefillRate = 0.25f;
    [SerializeField] private float burpExpelRate = 0.1f;
    [SerializeField] private float parpExpelRate = 0.1f;



    [SerializeField] private float rayLength = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _resetJump = false;
    private bool isEmittingGas = false;
    private PlayerAnimation playerAnimation;

    private SpriteRenderer playerSprite;
    [SerializeField] SpriteRenderer swordArcSprite;
    private bool grounded = false;

    private Vector3 swordPos;

    public int Health { get ; set; }
    public int diamonds = 0;
    public bool isDead = false;

    public float gasLevel = 100f;


    //handle to Player Animation



    void Start()
    {
        // get reference to rigidbody
        _rigid = gameObject.GetComponent<Rigidbody2D>();
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        playerSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        swordPos = swordArcSprite.transform.localPosition;
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Movement();
            Attack();
        }
        if (!isEmittingGas && gasLevel<100)
        {
            gasLevel = gasLevel + (gasRefillRate * Time.deltaTime);
            UIManager.Instance.UpdateHUDGasLevel(gasLevel);
        }
    }

    private void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded())
        {
            playerAnimation.GroundedAttack();
        }
    }

    private void Movement()
    {
        grounded = IsGrounded();
        float moveH = (CrossPlatformInputManager.GetAxis("Horizontal") * burpForce) *-1;
        //Flip(moveH);
        float moveV = (CrossPlatformInputManager.GetAxis("Vertical") * burpVerticalForce) *-1;
        Debug.Log("Adding vertical force: " + moveV.ToString());

        _rigid.AddForce(new Vector2(moveH, 0f));
        if (_rigid.velocity.y < maxUpVelocity)
        {
            _rigid.AddForce(new Vector2(0f, moveV));
        }

        playerAnimation.Move(moveH);
        if (moveH != 0 || moveV != 0)
        {
            gasLevel = gasLevel - (burpExpelRate * Time.deltaTime);
        }
        UIManager.Instance.UpdateHUDGasLevel(gasLevel);

        if ((Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("B_Button")))
        {
            Parp();
        }
    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            playerSprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;

            swordArcSprite.transform.localPosition = swordPos;
        }
        else if (move < 0)
        {
            playerSprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;
            swordArcSprite.transform.localPosition = new Vector3(-swordPos.x, swordPos.y, swordPos.z);
        }
    }

    private void Parp()
    {
        Debug.Log("parp!)");
        if (_rigid.velocity.y < maxUpVelocity)
        {
            _rigid.AddForce(new Vector2(0f, parpForce));
            Debug.Log("Adding vertical force: " + parpForce.ToString());
        }
        gasLevel = gasLevel - (parpExpelRate * Time.deltaTime);
        UIManager.Instance.UpdateHUDGasLevel(gasLevel);
        //StartCoroutine(ResetJumpRoutine());
        playerAnimation.Jump(true);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, rayLength, _groundLayer);

        if (hitInfo.collider !=null)
        {
            if (_resetJump == false)
            {
                playerAnimation.Jump(false);
                return true;
            }
        }

        return false;      
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if (!isDead)
        {
            Debug.Log("Player Damaged!");            
            Health--;            
            UIManager.Instance.UpdateLives(Health);            
            if (Health == 0)
            {
                playerAnimation.Death();
                isDead = true;
            }
        }        
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateHUDGemCount(diamonds);
    }
}
