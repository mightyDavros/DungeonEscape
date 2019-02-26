using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator
    private Animator playerAnimator;
    [SerializeField] GameObject swordSprite;
    private Animator swordAnimator;

    
    // Start is called before the first frame update
    void Start()
    {
        //assign handle to animator
        playerAnimator = gameObject.GetComponentInChildren<Animator>();
        swordAnimator = swordSprite.GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        //anim set float Move, move
        playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        playerAnimator.SetBool("Jumping", jumping);
    }

    public void GroundedAttack()
    {
        playerAnimator.SetTrigger("GroundedAttack");
        swordAnimator.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        playerAnimator.SetTrigger("Death");
    }
}
