using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeGranpa_PlayerController2D : MonoBehaviour
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

    [SerializeField]
    GameObject player1;

    bool isAttacking = false;

    bool isFacingLeft;

    public bool isAttackLocked = false;

    public bool isDirectionalAttackLocked = false;

    public bool isMoving = false; 

    public float maximumThrowDistance = 1.5f;

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
                Newanimator.Play("LeGranpa_LightJump");
                delay = .5f;
                StartCoroutine(DoLightJumpAttack(delay));
            }
            else
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("LeGranpa_LightNeutral");

                //Invoke("ResetAttack", .4f);
                StartCoroutine(DoAttack(delay));

            }
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("LeGranpa_LightHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoLightHighAttack(delay));
            }
            else if (isGrounded == true && Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("LeGranpa_LightLow");

                StartCoroutine(DoLightLowAttack(delay));

                //Invoke("ResetAttack", .4f);
            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) && !isAttacking)
        {

            isAttacking = true;
            float delay = .4f;

            if (!isGrounded)
            {
                Newanimator.Play("LeGranpa_HeavyJump");
                delay = 4.5f;

                StartCoroutine(DoHeavyJumpAttack(delay));
            }
            //else if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Keypad8))
            //{
            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            //Newanimator.Play("Player2_HeavyHigh");

            //StartCoroutine(DoHeavyHighAttack(delay));

            //Invoke("ResetAttack", .4f);


            //}
            // else if (isGrounded == true && Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Keypad8))
            //{
            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);
            //delay = .4f;
            // Newanimator.Play("Player2_HeavyHigh");

            //Invoke("ResetAttack", .4f);

            // StartCoroutine(DoHeavyLowAttack(delay));


            //}
            else if (isGrounded && Input.GetKeyDown(KeyCode.Keypad8))
            {
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                //delay = .4f;
                Newanimator.Play("LeGranpa_HeavyNeutral");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyNeutralAttack(delay));


            }


            //chose a random attack to play
            //int index = UnityEngine.Random.Range(1, 5);
            //Newanimator.Play("NewPlayer_Attack" + index);

            //Invoke("ResetAttack", .4f);

            //StartCoroutine(DoAttack(delay));
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded && !isDirectionalAttackLocked)
        {
            float wodelay = 3.4f;
            float wpdelay = 1.4f;
            if (Input.GetKey(KeyCode.Keypad8) && !isDirectionalAttackLocked)
            {


                //Debug.Log("this worked 2");
                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                wodelay = 1.4f;
                Newanimator.Play("LeGranpa_HeavyHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyHighAttack(wodelay));
            }
            else if (Input.GetKey(KeyCode.Keypad9) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                wpdelay = 1.4f;
                Newanimator.Play("LeGranpa_LightHigh");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoLightHighAttack(wpdelay));
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) && isGrounded && !isDirectionalAttackLocked)
        {
            float sodelay = 3.4f;
            float spdelay = 2.5f;
            if (Input.GetKey(KeyCode.Keypad8) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                sodelay = 1.5f;
                Newanimator.Play("LeGranpa_HeavyLow");

                //Invoke("ResetAttack", .4f);

                StartCoroutine(DoHeavyLowAttack(sodelay));
            }
            else if (Input.GetKey(KeyCode.Keypad9) && !isDirectionalAttackLocked)
            {

                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);
                spdelay = 1f;
                Newanimator.Play("LeGranpa_LightLow");

                //Invoke("ResetAttack", .4f);
                StartCoroutine(DoLightLowAttack(spdelay));

            }
            else
            {
                return;
            }
        }

        if (Input.GetKeyDown("[6]"))
        {
            if (isShooting)
            {
                return;
            }

            //audioSrc.Play();
            //shoot
            Newanimator.Play("LeGranpa_Throw");
            isShooting = true;

            GameObject b = Instantiate(bouncyBall);
            //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.GetComponent<LeGranpa_Projectile>().StartShoot(isFacingLeft);
            b.transform.position = bulletSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }


        if (Input.GetKey(KeyCode.K))
        {


            Vector3 difference = player1.transform.position - this.transform.position;
            if (difference.sqrMagnitude <= maximumThrowDistance)
            {
                if (player1.transform.localScale.x > 0)
                {
                    if (player1.transform.position.x < this.transform.position.x)
                    {
                        Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);
                    }
                }
                else
                {
                    if (player1.transform.position.x > this.transform.position.x)
                    {
                        Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);

                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.Keypad4) && isGrounded == true)
        {
            Newanimator.Play("LeGranpa_Grab");

        }



    }

    void ResetShoot()
    {
        isShooting = false;
        Newanimator.Play("LeGranpa_Idle");
    }







    IEnumerator DoAttack(float delay)
    {
        isAttackLocked = true;
        //attackHitbox.SetActive(true);
        attackHitboxLightNeutralStart.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        attackHitboxLightNeutralStart.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoLightHighAttack(float delay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxLightHigh.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightHigh.SetActive(true);
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoLightLowAttack(float delay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxLightLowStart.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightLowStart.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
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
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoHeavyNeutralAttack(float delay)
    {
        isAttackLocked = true;
        attackHitboxHeavyNeutral.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        attackHitboxHeavyNeutral.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
    }

    IEnumerator DoHeavyHighAttack(float delay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxHeavyHigh.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        attackHitboxHeavyHigh.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoHeavyLowAttack(float delay)
    {
        isDirectionalAttackLocked = true; 
        isAttackLocked = true;
        attackHitboxHeavyLow.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        attackHitboxHeavyLow.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;
        isAttacking = false;
        isDirectionalAttackLocked = false; 
    }

    IEnumerator DoHeavyJumpAttack(float delay)
    {
        isAttackLocked = true;
        attackHitboxHeavyJump.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        attackHitboxHeavyJump.SetActive(false);
        Newanimator.Play("LeGranpa_Idle");
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
        Newanimator.Play("LeGranpa_Idle");
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
                Newanimator.Play("LeGranpa_Jump");
            }

        }

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("LeGranpa_Run");


            //NewspriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("LeGranpa_Run");


            //NewspriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = true;
        }
        else if (isGrounded)
        {
            if (!isAttacking)
            {
                //Newanimator.Play("Player2_Idle");
            }

            Newrb2d.velocity = new Vector2(0, Newrb2d.velocity.y);
        }

        if (Input.GetKey("[0]") && isGrounded == true)
        {
            Newrb2d.velocity = new Vector2(Newrb2d.velocity.x, jumpSpeed);
            Newanimator.Play("LeGranpa_Jump");
        }
    }
}
