using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigid;
    private Collider2D[] _colliders;
    [SerializeField] private float speed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] private float rayLength = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _resetJump = false;
    private PlayerAnimation playerAnimation;
    private SpriteRenderer playerSprite;
    [SerializeField] SpriteRenderer swordArcSprite;
    private bool grounded = false;

    private Vector3 swordPos;

    public int Health { get ; set; }

    //handle to Player Animation



    void Start()
    {
        // get reference to rigidbody
        _rigid = gameObject.GetComponent<Rigidbody2D>();
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        playerSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        swordPos = swordArcSprite.transform.localPosition;


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            playerAnimation.GroundedAttack();
        }
    }

    private void Movement()
    {
        grounded = IsGrounded();
        float move = Input.GetAxisRaw("Horizontal") * speed;
        Flip(move);

        _rigid.velocity = new Vector2(move, _rigid.velocity.y);

        playerAnimation.Move(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Jump();
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

    private void Jump()
    {
        Debug.Log("jump!)");
        _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
        StartCoroutine(ResetJumpRoutine());
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
        Debug.Log("Player Damaged!");
    }
}
