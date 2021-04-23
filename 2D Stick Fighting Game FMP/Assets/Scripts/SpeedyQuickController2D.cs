﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyQuickController2D : MonoBehaviour
{
    Animator Newanimator;
    Rigidbody2D Newrb2d;
    SpriteRenderer NewspriteRenderer;

    bool isGrounded;

    [SerializeField]
    GameObject LightningBolt;

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
    private float runSpeed = 3f;

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

    // Start is called before the first frame update
    void Start()
    {
        Newanimator = GetComponent<Animator>();
        Newrb2d = GetComponent<Rigidbody2D>();
        NewspriteRenderer = GetComponent<SpriteRenderer>();
        attackHitbox.SetActive(false);
        isAttackLocked = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackLocked)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad9) && !isAttacking)
            {
                //isAttacking = false; 
                float delay = .4f;

                if (!isGrounded)
                {
                    Newanimator.Play("SpeedyQuick_LightJump");
                    delay = .5f;
                    StartCoroutine(DoLightJumpAttack(delay));
                }
                else
                {  
                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    //delay = .4f;
                    Newanimator.Play("SpeedyQuick_LightNeutral");

                    //Invoke("ResetAttack", .4f);
                    StartCoroutine(DoAttack(delay));

                }
                if (isGrounded == true && Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    //delay = .4f;
                    Newanimator.Play("SpeedyQuick_LightNeutral");

                    //Invoke("ResetAttack", .4f);

                    StartCoroutine(DoLightHighAttack(delay));
                }
                else if (isGrounded == true && Input.GetKeyDown(KeyCode.Keypad9) && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    //delay = .4f;
                    Newanimator.Play("SpeedyQuick_LightLow");

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

              
                float delay = .4f;

                if (!isGrounded)
                {
                    Newanimator.Play("SpeedyQuick_HeavyJump");
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
                    Newanimator.Play("SpeedyQuick_HeavyNeutral");

                    //Invoke("ResetAttack", .4f);

                    StartCoroutine(DoHeavyNeutralAttack(delay));


                }


                //chose a random attack to play
                //int index = UnityEngine.Random.Range(1, 5);
                //Newanimator.Play("NewPlayer_Attack" + index);

                //Invoke("ResetAttack", .4f);

                //StartCoroutine(DoAttack(delay));
            }

            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                float wodelay = 3.4f;
                float wpdelay = 1.4f;
                if (Input.GetKey(KeyCode.Keypad8))
                {


                    //Debug.Log("this worked 2");
                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    wodelay = 1.4f;
                    Newanimator.Play("SpeedyQuick_HeavyHigh");

                    //Invoke("ResetAttack", .4f);

                    StartCoroutine(DoHeavyHighAttack(wodelay));
                }
                else if (Input.GetKey(KeyCode.Keypad9))
                {

                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    wpdelay = 1.4f;
                    Newanimator.Play("SpeedyQuick_LightHigh");

                    //Invoke("ResetAttack", .4f);

                    StartCoroutine(DoLightHighAttack(wpdelay));
                }
                else
                {
                    return;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
            {
                float sodelay = 3.4f;
                float spdelay = 2.5f;
                if (Input.GetKey(KeyCode.Keypad8))
                {

                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    sodelay = 1.5f;
                    Newanimator.Play("SpeedyQuick_HeavyLow");

                    //Invoke("ResetAttack", .4f);

                    StartCoroutine(DoHeavyLowAttack(sodelay));
                }
                else if (Input.GetKey(KeyCode.Keypad9))
                {

                    //chose a random attack to play
                    //int index = UnityEngine.Random.Range(1, 5);
                    //Newanimator.Play("NewPlayer_Attack" + index);
                    spdelay = 1f;
                    Newanimator.Play("SpeedyQuick_LightLow");

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
                Newanimator.Play("SpeedyQuick_Throw");
                isShooting = true;

                GameObject b = Instantiate(LightningBolt);
                //b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
                b.GetComponent<SpeedyQuickLightningBolt>().StartShoot(isFacingLeft);
                b.transform.position = bulletSpawnPos.transform.position;

                Invoke("ResetShoot", shootDelay);
            }


            if (Input.GetKey(KeyCode.K) && isGrounded == true)
            {


                Vector3 difference = player1.transform.position - this.transform.position;
                if (difference.sqrMagnitude <= 1)
                {
                    Newrb2d.velocity = new Vector2(Newrb2d.velocity.x - 4, 7);
                }
            }

            if (Input.GetKey(KeyCode.Keypad4) && isGrounded == true)
            {
                Newanimator.Play("SpeedyQuick_Grab");

            }



        }
    }

    void ResetShoot()
    {
        isShooting = false;
        Newanimator.Play("SpeedyQuick_Idle");
    }







    IEnumerator DoAttack(float delay)
    {
       isAttackLocked = true;
        //isAttacking = true; 
        
        //attackHitbox.SetActive(true);
        attackHitboxLightNeutralStart.SetActive(true);
        
        yield return new WaitForSeconds(.4f);
        attackHitbox.SetActive(false);
        attackHitboxLightNeutralStart.SetActive(false);
        Newanimator.Play("SpeedyQuick_Idle");
      
        //isAttacking = false;
        yield return new WaitForSeconds(.1f);
       isAttackLocked = false;
        

    }

    IEnumerator DoLightHighAttack(float delay)
    {
        isAttackLocked = true;
        //isAttacking = true; 
        attackHitboxLightHigh.SetActive(true);
        
        yield return new WaitForSeconds(.4f);
        attackHitboxLightHigh.SetActive(true);
        //isAttacking = false;

        yield return new WaitForSeconds(.1f);
        
        isAttackLocked = false; 
    }

    IEnumerator DoLightLowAttack(float delay)
    {
        isAttackLocked = true;

        attackHitboxLightLowStart.SetActive(true);
     
        yield return new WaitForSeconds(.4f);
        attackHitboxLightLowStart.SetActive(false);


        yield return new WaitForSeconds(.1f);
  
        isAttackLocked = false; 
    }

    IEnumerator DoLightJumpAttack(float delay)
    {
        isAttackLocked = true;

        attackHitboxLightJump.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitboxLightJump.SetActive(false);
        isAttacking = false;

        yield return new WaitForSeconds(.1f);
        isAttackLocked = false;         
    }

    IEnumerator DoHeavyNeutralAttack(float delay)
    {
        isAttackLocked = true;

        attackHitboxHeavyNeutral.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        attackHitboxHeavyNeutral.SetActive(false);

        yield return new WaitForSeconds(1f);
        isAttackLocked = false; 

        isAttacking = false;
    }

    IEnumerator DoHeavyHighAttack(float delay)
    {

        attackHitboxHeavyHigh.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        attackHitboxHeavyHigh.SetActive(false);
        isAttacking = false;

       
    }

    IEnumerator DoHeavyLowAttack(float delay)
    {
        attackHitboxHeavyLow.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        attackHitboxHeavyLow.SetActive(false);
        isAttacking = false;
    }

    IEnumerator DoHeavyJumpAttack(float delay)
    {
        attackHitboxHeavyJump.SetActive(true);
        yield return new WaitForSeconds(2.4f);
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
                Newanimator.Play("SpeedyQuick_Jump");
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Newrb2d.velocity = new Vector2(runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("SpeedyQuick_Run");


            //NewspriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Newrb2d.velocity = new Vector2(-runSpeed, Newrb2d.velocity.y);
            if (isGrounded && !isAttacking)
                Newanimator.Play("SpeedyQuick_Run");


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
            Newanimator.Play("Player2_Jump");
        }
    }
}
