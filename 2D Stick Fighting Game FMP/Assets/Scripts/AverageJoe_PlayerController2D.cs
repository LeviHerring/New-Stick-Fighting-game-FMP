using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageJoe_PlayerController2D : MonoBehaviour
{
    Animator Newanimator;
    Rigidbody2D Newrb2d;
    SpriteRenderer NewspriteRenderer;

    bool isGrounded;


    [SerializeField]
    GameObject attackHitbox;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;



    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 3;

    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        Newanimator = GetComponent<Animator>();
        Newrb2d = GetComponent<Rigidbody2D>();
        NewspriteRenderer = GetComponent<SpriteRenderer>();
        attackHitbox.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isAttacking)
        {
            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("AverageJoe_LightJump");
                delay = .5f;
            }
            else
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightNeutral");

                //Invoke("ResetAttack", .4f);


            }
            if (isGrounded == true &&  Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.W))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightHigh");

                //Invoke("ResetAttack", .4f);
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.S))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightLow");

                //Invoke("ResetAttack", .4f);
            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            StartCoroutine(DoAttack(delay));
        }
        else if (Input.GetKeyDown(KeyCode.O) && !isAttacking)
        {

            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("AverageJoe_HeavyJump");
                delay = .5f;
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyHigh");

                //Invoke("ResetAttack", .4f);


            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyHigh");

                //Invoke("ResetAttack", .4f);


            }
            else if (isGrounded && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyNeutral");

                //Invoke("ResetAttack", .4f);


            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            StartCoroutine(DoAttack(delay));
        }



    }
    

    IEnumerator DoAttack(float delay)
    {
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
    void ResetAttack()
    {
        isAttacking = false;
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
            if (!isAttacking)
            {
                Newanimator.Play("AverageJoe_Jump");
            }

        }

        if (Input.GetKey("d"))
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("AverageJoe_Run");


            //NewspriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey("a"))
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("AverageJoe_Run");


            //NewspriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (isGrounded)
        {
            if (!isAttacking)
            {
                Newanimator.Play("AverageJoe_Idle");
            }

            Newrb2d.velocity = new Vector2(0, Newrb2d.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x, jumpSpeed);
            Newanimator.Play("AverageJoe_Jump");
        }
    }
}
