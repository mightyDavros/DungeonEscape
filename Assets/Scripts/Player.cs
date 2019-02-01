using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Collider2D[] _colliders;
    [SerializeField] float moveMultiplier = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] private float rayLength = 1.0f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _resetJump = false;


    // Start is called before the first frame update
    void Start()
    {
        // get reference to rigidbody
        _rigid = gameObject.GetComponent<Rigidbody2D>();
        _rigid.GetAttachedColliders(_colliders); //not working!
        print(_colliders);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

  
    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal") * moveMultiplier;
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded() == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("jump!)");
        _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
        StartCoroutine(ResetJumpRoutine());
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, rayLength, _groundLayer);

        if (hitInfo.collider !=null)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
