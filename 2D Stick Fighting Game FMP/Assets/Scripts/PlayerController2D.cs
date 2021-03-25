using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{


    AudioSource audioSrc;
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform bulletSpawnPos;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    GameObject Player2; 

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 5;
    private bool isShooting;

    [SerializeField]
    private float shootDelay = 0.5f;

    bool isFacingLeft;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
        Player2 = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isShooting)
            {
                return;
            }

            //audioSrc.Play();
            //shoot
            animator.Play("Player_Shoot");
            isShooting = true;

            GameObject b = Instantiate(bullet);
            //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.GetComponent<NewBulletScript>().StartShoot(isFacingLeft);
            b.transform.position = bulletSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }
    }

    void ResetShoot()
    {
        isShooting = false;
        animator.Play("Player_Idle");
    }

    private void FixedUpdate()
    {
        if((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
                {
            isGrounded = true;
        }
        
            

        
        else
        {
            isGrounded = false;
            animator.Play("Player_Jump");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if(isGrounded)
            animator.Play("Player_Run");


            spriteRenderer.flipX = false;

            isFacingLeft = false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            if (isGrounded)
                animator.Play("Player_Run");
            
            
            spriteRenderer.flipX = true;

            isFacingLeft = true;
        }
        else
        {
            if (isGrounded)
                animator.Play("Player_Idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded == true)
        { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Player_Jump");
        }


    }

   



}
