using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    Animator Newanimator;
    Rigidbody2D Newrb2d;
    SpriteRenderer NewspriteRenderer;

    bool isGrounded;

    [SerializeField]
    GameObject bouncyBall;

    [SerializeField]
    Transform bulletSpawnPos;

    [SerializeField]
    GameObject attackHitbox;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    Transform ThrowPosition;

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 3;
    private bool isShooting;

    [SerializeField]
    private float shootDelay = 0.5f;

    [SerializeField]
    float speed = 1f;

    bool isAttacking = false;

    bool isFacingLeft;

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
        if (Input.GetKeyDown(KeyCode.Keypad9) && !isAttacking)
        {
            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("Player2_LightJump");
                delay = .5f;
            }
            else
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_LightNeutral");

                //Invoke("ResetAttack", .4f);


            }
            if (isGrounded == true &&  Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_LightHigh");

                //Invoke("ResetAttack", .4f);
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_LightLow");

                //Invoke("ResetAttack", .4f);
            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            StartCoroutine(DoAttack(delay));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) && !isAttacking)
        {

            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("Player2_HeavyJump");
                delay = .5f;
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Keypad8))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_HeavyHigh");

                //Invoke("ResetAttack", .4f);


            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Keypad8))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_HeavyHigh");

                //Invoke("ResetAttack", .4f);


            }
            else if (isGrounded && Input.GetKeyDown(KeyCode.Keypad8))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("Player2_HeavyNeutral");

                //Invoke("ResetAttack", .4f);


            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            StartCoroutine(DoAttack(delay));
        }

        if (Input.GetKeyDown("[6]"))
        {
            if (isShooting)
            {
                return;
            }

            //audioSrc.Play();
            //shoot
            Newanimator.Play("Player2_Throw");
            isShooting = true;

            GameObject b = Instantiate(bouncyBall);
            //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.GetComponent<Player2BouncyBall>().StartShoot(isFacingLeft);
            b.transform.position = bulletSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }


        if (Input.GetKey(KeyCode.K) && isGrounded == true)
        {
            
           Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);
        }

        if (Input.GetKey(KeyCode.Keypad4) && isGrounded == true)
        {
            Newanimator.Play("Player2_Grab");
        }
    }

    void ResetShoot()
    {
        isShooting = false;
        Newanimator.Play("Player2_Idle");
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
                Newanimator.Play("Player2_Jump");
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("Player2_Run");


            //NewspriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("Player2_Run");


            //NewspriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = true;
        }
        else if (isGrounded)
        {
            if (!isAttacking)
            {
                Newanimator.Play("Player2_Idle");
            }

            Newrb2d.velocity = new Vector2(0, Newrb2d.velocity.y);
        }

        if (Input.GetKey("[0]") && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x, jumpSpeed);
            Newanimator.Play("Player2_Jump");
        }
    }
}
