using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuMan_PlayerController2D : MonoBehaviour
{
    Animator Newanimator;
    Rigidbody2D Newrb2d;
    SpriteRenderer NewspriteRenderer;

    public bool isGrounded;

    [SerializeField]
    GameObject bouncyBall;

    [SerializeField]
    Transform bulletSpawnPos;

    [SerializeField]
    GameObject attackHitbox;

    [SerializeField]
    GameObject attackHitboxLightNeutralStart;


    [SerializeField]
    GameObject attackHitboxLightLowStart;

    [SerializeField]
    GameObject attackHitboxLightHigh;


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
    private float runSpeed = 2.5f;

    [SerializeField]
    private float jumpSpeed = 5f;
    private bool isShooting;

    [SerializeField]
    private float shootDelay = 0.1f;

    [SerializeField]
    GameObject player2;

    bool isAttacking = false;

    bool isFacingLeft;

    public bool isAttackLocked = false;

    public bool isDirectionalAttackLocked = false;

    public bool isMoving = false; 

    float maximumThrowDistance = 1.5f;

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
        if (Input.GetKey(KeyCode.P) && !isAttacking)
        {
            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("GokuMan_LightJump");
                delay = .5f;
                StartCoroutine(DoLightJumpAttack(delay));
            }
            else
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                delay = .4f;
                Newanimator.Play("GokuMan_LightNeutral");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoAttack(delay));
            }
            //if (isGrounded == true &&  Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.W))
            // {
            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            //Newanimator.Play("AverageJoe_LightHigh");

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoLightHighAttack(delay));
            //}
            //else if (isGrounded == true && Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.S))
            // {
            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            //Newanimator.Play("AverageJoe_LightLow");

            //Invoke("ResetAttack", .4f);
            //StartCoroutine(DoLightLowAttack(delay));

            //}


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }
        else if (Input.GetKey(KeyCode.O) && !isAttacking)
        {

            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("GokuMan_HeavyJump");
                delay = 7.5f;
                StartCoroutine(DoHeavyJumpAttack(delay));
            }



            //var test1 = 5 - 6;
            //var test2 = +3;

            //var totalTest = test1 + test2;
            //var x = 5 - 6 + 3;



            //bool test1 = isGrounded == true;
            //bool test2 = Input.GetKey(KeyCode.S);
            //bool test3 = Input.GetKey(KeyCode.O);

            //if (isGrounded == true && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.O))
            //{
            // Debug.Log("this worked");

            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            //Newanimator.Play("AverageJoe_HeavyHigh");

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoLightHighAttack(delay));
            //}
            //else if (isGrounded == true && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.O))
            //{
            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            //Newanimator.Play("AverageJoe_HeavyLow");

            //Invoke("ResetAttack", .4f);

            // StartCoroutine(DoHeavyLowAttack(delay));

            //}
            else if (isGrounded && Input.GetKey(KeyCode.O))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("GokuMan_HeavyNeutral");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyNeutralAttack(delay));

            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }

        if (Input.GetKey(KeyCode.W) && isGrounded && !isDirectionalAttackLocked)
        {
            float wodelay = 3.4f;
            float wpdelay = 3.5f;
            if (Input.GetKey(KeyCode.O) && !isDirectionalAttackLocked)
            {


                //Debug.Log("this worked 2");
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                wodelay = 3.4f;
                Newanimator.Play("GokuMan_HeavyHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyHighAttack(wodelay));
            }
            else if (Input.GetKey(KeyCode.P) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                wpdelay = 1.4f;
                Newanimator.Play("GokuMan_LightHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoLightHighAttack(wpdelay));
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.S) && isGrounded && !isDirectionalAttackLocked)
        {
            float sodelay = 4.5f;
            float spdelay = 5.6f;
            if (Input.GetKey(KeyCode.O) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                sodelay = 4.5f;
                Newanimator.Play("GokuMan_HeavyLow");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyLowAttack(sodelay));
            }
            else if (Input.GetKey(KeyCode.P) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                spdelay = 1f;
                Newanimator.Play("GokuMan_LightLow");

                //Invoke("ResetAttack", .4f);
                StartCoroutine(DoLightLowAttack(spdelay));

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
            Newanimator.Play("GokuMan_Throw");
            isShooting = true;

            GameObject b = Instantiate(bouncyBall);
            //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.GetComponent<GokuMan_FireBalls>().StartShoot(isFacingLeft);
            b.transform.position = bulletSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {

            Vector3 difference = player2.transform.position - this.transform.position;
            if (difference.sqrMagnitude <= maximumThrowDistance)
            {
                if (player2.transform.localScale.x > 0)
                {
                    if (player2.transform.position.x < this.transform.position.x)
                    {
                        Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);
                    }
                }
                else
                {
                    if (player2.transform.position.x > this.transform.position.x)
                    {
                        Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);

                    }
                }
            }

        }

        if (Input.GetKey(KeyCode.K) && isGrounded == true)
        {

            Newanimator.Play("GokuMan_Grab");
        }

    }

    void ResetShoot()
    {
        isShooting = false;
        Newanimator.Play("GokuMan_Idle");
    }







    IEnumerator DoAttack(float delay)
    {
        isAttackLocked = true;
        attackHitbox.SetActive(true);
        attackHitboxLightNeutralStart.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        attackHitboxLightNeutralStart.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoLightHighAttack(float wpdelay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxLightHigh.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightHigh.SetActive(true);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoLightLowAttack(float spdelay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxLightLowStart.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightLowStart.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoLightJumpAttack(float delay)
    {
        isAttackLocked = true;
        attackHitboxLightJump.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightJump.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoHeavyNeutralAttack(float delay)
    {
        isAttackLocked = true;
        attackHitboxHeavyNeutral.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyNeutral.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoHeavyHighAttack(float wodelay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxHeavyHigh.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyHigh.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoHeavyLowAttack(float sodelay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxHeavyLow.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyLow.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoHeavyJumpAttack(float delay)
    {
        isAttackLocked = true;
        attackHitboxHeavyJump.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxHeavyJump.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }


    IEnumerator DoGrabAttack(float delay)
    {
        isAttackLocked = true;
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        Newanimator.Play("GokuMan_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
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
                Newanimator.Play("GokuMan_Jump");
            }

        }

        if (Input.GetKey("d") && !isMoving)
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("GokuMan_Run");


            //NewspriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;

        }
        else if (Input.GetKey("a") && !isMoving)
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("GokuMan_Run");


            //NewspriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);

            isFacingLeft = true;
        }
        else if (isGrounded)
        {
            if (!isAttacking)
            {

                //Newanimator.Play("AverageJoe_Idle");
            }

            Newrb2d.velocity = new Vector2(0, Newrb2d.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x, jumpSpeed);
            Newanimator.Play("GokuMan_Jump");
        }
    }
}

