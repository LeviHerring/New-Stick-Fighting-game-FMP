using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController2D : MonoBehaviour
{

    Animator Newanimator;
    Rigidbody2D Newrb2d;
    SpriteRenderer NewspriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;



    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Newanimator = GetComponent<Animator>();
        Newrb2d = GetComponent<Rigidbody2D>();
        NewspriteRenderer = GetComponent<SpriteRenderer>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;
        }




        else
        {
            isGrounded = false;
            Newanimator.Play("NewPlayer_Jump");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded)
                Newanimator.Play("NewPlayer_Run");


            NewspriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded)
                Newanimator.Play("NewPlayer_Run");


            NewspriteRenderer.flipX = true;
        }
        else
        {
            if (isGrounded)
                Newanimator.Play("NewPlayer_Idle");
            Newrb2d.velocity = new Vector2(0, Newrb2d.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x, jumpSpeed);
            Newanimator.Play("NewPlayer_Jump");
        }
    }

}
