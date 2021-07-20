using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed< 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Code to make crouch animation 
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
        }else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
        }

        // Code to make jump animation
        //float jump = Input.GetAxisRaw("Jump");
                                                                             if (Input.GetKeyDown(KeyCode.Space))
      //if (jump > 0)
        {
            animator.SetBool("isJump", true);
        }else                                                                if (Input.GetKeyUp(KeyCode.Space))
        {
           animator.SetBool("isJump", false);
        }

    }
}
