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
    private float vertical;
    public float jump;
    private bool crouching;
    private Rigidbody2D rb2d;
    [SerializeField] private GameManage gamemanager;
    public float health;

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
         vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouching = true;
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            crouching = false;
            
      animator.SetBool("isJump", vertical > 0);
      animator.SetBool("isCrouch", crouching);
        CheckHealth();
    }
    private void FixedUpdate()
    { 
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        rb2d.AddForce(new Vector2(0f, (vertical*jump)), ForceMode2D.Force);
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
    }

        private void OnCollisionEnter2D (Collision2D collision)
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

