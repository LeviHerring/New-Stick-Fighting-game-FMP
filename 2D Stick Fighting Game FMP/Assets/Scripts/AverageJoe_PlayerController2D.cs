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
    GameObject bouncyBall;

    [SerializeField]
    Transform bulletSpawnPos;

    [SerializeField]
    GameObject attackHitbox;

    [SerializeField]
    GameObject attackHitboxLightNeutralStart;

    [SerializeField]
    GameObject attackHitboxLightNeutralEnd;

    [SerializeField]
    GameObject attackHitboxLightLowStart;

    [SerializeField]
    GameObject attackHitboxLightLowMiddle;

    [SerializeField]
    GameObject attackHitboxLightLowEnd;

    [SerializeField]
    GameObject attackHitboxLightHigh;

    [SerializeField]
    GameObject attackHitboxLHEnd;

    [SerializeField]
    GameObject attackHitboxHeavyNeutral;

    [SerializeField]
    GameObject attackHitboxHeavyLow;

    [SerializeField]
    GameObject attackHitboxHeavyHigh;

    [SerializeField]
    GameObject attackHitboxHeavyJump;

    [SerializeField]
    GameObject attackHitboxLightJump;

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
    private bool isShooting;

    [SerializeField]
    private float shootDelay = 0.5f;

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
        if (Input.GetKeyDown(KeyCode.P) && !isAttacking)
        {
            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("AverageJoe_LightJump");
                delay = .5f;
                StartCoroutine(DoLightJumpAttack(delay));
            }
            else
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                delay = .4f;
                Newanimator.Play("AverageJoe_LightNeutral");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoAttack(delay));
            }
            if (isGrounded == true &&  Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.W))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoLightHighAttack(delay));
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.S))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightLow");

                //Invoke("ResetAttack", .4f);
                StartCoroutine(DoLightLowAttack(delay));

            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }
        else if (Input.GetKeyDown(KeyCode.O) && !isAttacking)
        {

            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("AverageJoe_HeavyJump");
                delay = .5f;
                StartCoroutine(DoHeavyJumpAttack(delay));
            }
            if (isGrounded == true && Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoLightHighAttack(delay));
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyLow");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyLowAttack(delay));

            }
            else if (isGrounded && Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyNeutral");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyNeutralAttack(delay));

            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyHigh");

                //Invoke("ResetAttack", .4f);
            }
            else if(Input.GetKeyDown(KeyCode.P))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightHigh");

                //Invoke("ResetAttack", .4f);
            }
            else
            {
                return; 
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_HeavyLow");

                //Invoke("ResetAttack", .4f);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("AverageJoe_LightLow");

                //Invoke("ResetAttack", .4f);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (isShooting)
            {
                return;
            }

            //audioSrc.Play();
            //shoot
            Newanimator.Play("AverageJoe_Throw");
            isShooting = true;

            GameObject b = Instantiate(bouncyBall);
            //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.GetComponent<BouncyBallScript>().StartShoot(isFacingLeft);
            b.transform.position = bulletSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }

        if(Input.GetKey(KeyCode.Keypad4) && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x + 4, 7);
        }

        if (Input.GetKey(KeyCode.K) && isGrounded == true)
        {

            Newanimator.Play("Player2_Grab");
        }

    }

    void ResetShoot()
    {
        isShooting = false;
        Newanimator.Play("AverageJoe_Idle");
    }







    IEnumerator DoAttack(float delay)
    {
        attackHitbox.SetActive(true);
        attackHitboxLightNeutralStart.SetActive(true);
        attackHitboxLightNeutralEnd.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        attackHitboxLightNeutralStart.SetActive(false);
        attackHitboxLightNeutralEnd.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoLightHighAttack(float delay)
    {
        attackHitboxLightHigh.SetActive(true);
        attackHitboxLHEnd.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightHigh.SetActive(true);
        attackHitboxLHEnd.SetActive(true);
        isAttacking = false;
    }

    IEnumerator DoLightLowAttack(float delay)
    {
        attackHitboxLightLowStart.SetActive(true);
        attackHitboxLightLowMiddle.SetActive(true);
        attackHitboxLightLowEnd.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightLowStart.SetActive(false);
        attackHitboxLightLowMiddle.SetActive(false);
        attackHitboxLightLowEnd.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoLightJumpAttack(float delay)
    {
        attackHitboxLightJump.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightJump.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoHeavyNeutralAttack(float delay)
    {
        attackHitboxHeavyNeutral.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyNeutral.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoHeavyHighAttack(float delay)
    {
        attackHitboxHeavyHigh.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyHigh.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoHeavyLowAttack(float delay)
    {
        attackHitboxHeavyLow.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyLow.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoHeavyJumpAttack(float delay)
    {
        attackHitboxHeavyJump.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyJump.SetActive(false);
        isAttacking = false;
    }


    IEnumerator DoGrabAttack(float delay)
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
            isFacingLeft = false;

        }
        else if (Input.GetKey("a"))
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("AverageJoe_Run");


            //NewspriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);

            isFacingLeft = true;
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
