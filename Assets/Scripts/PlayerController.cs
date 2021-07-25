using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        
        // Code to make crouch animation 
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", false);
        }
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        // if a = a + b, then it cas also be written as a += b
        position.x += horizontal * speed * Time.deltaTime; // (Distance/Sec) * (1/30/sec)
        transform.position = position;

        //move character vertically
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }


    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        // Code to make jump animation

        //if (Input.GetKeyDown(KeyCode.Space))
        if (vertical > 0)
        {
            animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
        }

    }
}
