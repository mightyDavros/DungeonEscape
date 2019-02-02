using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        //assign handle to animator
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
        //anim set float Move, move
        animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        animator.SetBool("Jumping", jumping);
    }
}
