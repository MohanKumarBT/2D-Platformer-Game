
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    private float horizontal;
    private bool Jumping;
    public float jump;
    private bool crouching;
    private Rigidbody2D rb2d;
    [SerializeField] private GameManage gamemanager;
    public int health;
    [SerializeField] private LayerMask Groundlayer;
    [SerializeField] private Transform GroundCheck;
    private bool isGrounded;
    //private bool HoldingGun = false;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouching = true;
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            crouching = false; 
        animator.SetBool("isCrouch", crouching);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
            animator.SetBool("isJump",true);
        }
               CheckHealth();
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    HoldingGun = true;
        //}else if ((Input.GetKeyUp(KeyCode.Mouse0)))
        //    {
        //    HoldingGun = false;
        //}
    }
    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] collider = Physics2D.OverlapCircleAll(GroundCheck.position, 0.2f,Groundlayer);
        for (int i = 0; i < collider.Length; i++)
        { 
            if (collider[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                {
                    animator.SetBool("isJump", false);
                }

            }
        }

        MoveCharacter(horizontal, Jumping);
        PlayMovementAnimation(horizontal);
        //animator.SetBool("holdingGun", HoldingGun);
        //Debug.Log(HoldingGun);
        Jumping = false;

    }
    private void MoveCharacter(float horizontal, bool Jumping)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (isGrounded && Jumping)
        {
            isGrounded = false;
            rb2d.AddForce(new Vector2(0f, jump));
        }
    }

    private void PlayMovementAnimation(float horizontal)
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            health -= 1;
            gamemanager.Heart(health);
        }
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            animator.SetTrigger("dead");
            speed = 0;
        }
    }
}


