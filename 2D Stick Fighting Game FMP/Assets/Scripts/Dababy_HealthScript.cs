using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dababy_HealthScript : MonoBehaviour
{
    Animator Newanimator;

    public Image healthImage;
    public GameObject gameOver;
    public Image superMetreImage;
    public Image roundOne;
    public Image roundTwo;
    public Image roundThree;

    private Dababy_Shield dababyShield;
    public float health = 1f;
    public float superMetreCharge = 1f;
    public float roundOneFill = 0;
    public float roundTwoFill = 0;
    public float roundThreeFill = 0;
    public float roundsWon = 0;

    /*[SerializeField]
    [GameObject attackHitboxSpecial;

    [SerializeField]
    GameObject attackHitboxSpecial2;

    [SerializeField]
    GameObject attackHitboxSpecial3;

    [SerializeField]
    GameObject attackHitboxSpecial4;

    [SerializeField]
    GameObject attackHitboxSpecial5;

    [SerializeField]
    GameObject attackHitboxSpecial6;

    [SerializeField]
    GameObject attackHitboxSpecial7;

    [SerializeField]
    Collider2D BigHitbox;*/


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Newanimator = GetComponent<Animator>();
        health = 1f;
        superMetreCharge = 1f;
        roundsWon = 0;
        roundOneFill = 0;
        roundTwoFill = 0;
        roundThreeFill = 0;
        healthImage.fillAmount = health;
        gameOver.SetActive(false);
        

    }

    private void OnEnable()
    {
        dababyShield = GetComponent<Dababy_Shield>();
    }

    void TakeDamage(float amount)
    {
        health -= amount;
        healthImage.fillAmount = health;

    }

    void SuperMeter(float superAmount)
    {
        superMetreCharge -= superAmount;
        superMetreImage.fillAmount = superMetreCharge;
    }

    /*void Rounds()
    {
        if (health == 0)
        {
            roundsWon++;
            if (roundsWon == 1)
            {
                roundOneFill = 1f;
                roundOne.fillAmount = roundOneFill;
            }
        }
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dababyShield.ActiveShield)
        {
            if (collision.tag == "Spike")
            {
                TakeDamage(0.1f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Flame")
            {
                TakeDamage(0.5f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2 _LightNeutral")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2_LightLow")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2 _LightHigh")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2 _LightJump")
            {
                TakeDamage(0.03f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2_HeavyNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2_HeavyHigh")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2_HeavyLow")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2_HeavyJump")
            {
                TakeDamage(0.075f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            if (collision.tag == "Spike")
            {
                TakeDamage(0.1f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Flame")
            {
                TakeDamage(0.5f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "SpeedyQuick_LightNeutral")
            {
                TakeDamage(0.01f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_LightLow")
            {
                TakeDamage(0.015f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_LightHigh")
            {
                TakeDamage(0.015f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_HeavyNeutral")
            {
                TakeDamage(0.04f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_HeavyHigh")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_HeavyLow")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "SpeedyQuick_HeavyJump")
            {
                TakeDamage(0.065f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Player2 _Grab")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_LightNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_LightLow")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_LightHIGH")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_HeavyNeutral")
            {
                TakeDamage(0.15f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_HeavyHigh")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_HeavyLow")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "VegetaMan_HeavyJump")
            {
                TakeDamage(0.045f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_LightNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_LightLow")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_LightHigh")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_HeavyNeutral")
            {
                TakeDamage(0.15f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_HeavyHigh")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_HeavyLow")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LeGranpa_HeavyJump")
            {
                TakeDamage(0.045f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Bullet2")
            {
                Destroy(collision.gameObject);
                TakeDamage(0.04f);
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
                SceneManager.LoadScene(4);
                health = 1f;
            }

            else if (dababyShield.ActiveShield)
            {
                if (collision.tag == "Bullet2")
                {
                    Destroy(collision.gameObject);
                    TakeDamage(0.004f);
                }

                else if (collision.tag == "Player2 _LightNeutral")
                {
                    TakeDamage(0.00002f);
                }
                else if (collision.tag == "Player2_LightLow")
                {
                    TakeDamage(0.00025f);
                }
                else if (collision.tag == "Player2 _LightHigh")
                {
                    TakeDamage(0.00025f);
                }
                else if (collision.tag == "Player2 _LightJump")
                {
                    TakeDamage(0.0003f);
                }
                else if (collision.tag == "Player2_HeavyNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Player2_HeavyHigh")
                {
                    TakeDamage(0.0006f);
                }
                else if (collision.tag == "Player2_HeavyLow")
                {
                    TakeDamage(0.0006f);
                }
                else if (collision.tag == "Player2_HeavyJump")
                {
                    TakeDamage(0.00075f);
                }
                else if (collision.tag == "SpeedyQuick_LightNeutral")
                {
                    TakeDamage(0.001f);
                }
                else if (collision.tag == "SpeedyQuick_LightLow")
                {
                    TakeDamage(0.0015f);
                }
                else if (collision.tag == "SpeedyQuick_LightHigh")
                {
                    TakeDamage(0.00015f);
                }
                else if (collision.tag == "SpeedyQuick_LightJump")
                {
                    TakeDamage(0.0002f);
                }
                else if (collision.tag == "SpeedyQuick_HeavyNeutral")
                {
                    TakeDamage(0.0004f);
                }
                else if (collision.tag == "SpeedyQuick_HeavyHigh")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "SpeedyQuick_HeavyLow")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "SpeedyQuick_HeavyJump")
                {
                    TakeDamage(0.00065f);
                }
                else if (collision.tag == "VegetaMan_LightNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "VegetaMan_LightLow")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "VegetaMan_LightHIGH")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "VegetaMan_LightJump")
                {
                    TakeDamage(0.0002f);
                }
                else if (collision.tag == "VegetaMan_HeavyNeutral")
                {
                    TakeDamage(0.00015f);
                }
                else if (collision.tag == "VegetaMan_HeavyHigh")
                {
                    TakeDamage(0.0007f);
                }
                else if (collision.tag == "VegetaMan_HeavyLow")
                {
                    TakeDamage(0.0007f);
                }
                else if (collision.tag == "VegetaMan_HeavyJump")
                {
                    TakeDamage(0.00045f);
                }
                else if (collision.tag == "LeGranpa_LightNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "LeGranpa_LightLow")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "LeGranpa_LightHigh")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "LeGranpa_LightJump")
                {
                    TakeDamage(0.0002f);
                }
                else if (collision.tag == "LeGranpa_HeavyNeutral")
                {
                    TakeDamage(0.00015f);
                }
                else if (collision.tag == "LeGranpa_HeavyHigh")
                {
                    TakeDamage(0.0007f);
                }
                else if (collision.tag == "LeGranpa_HeavyLow")
                {
                    TakeDamage(0.00007f);
                }
                else if (collision.tag == "LeGranpa_HeavyJump")
                {
                    TakeDamage(0.000045f);
                }
            }
        }

        //if (collision.CompareTag("Bullet)"))
        //{
        //Destroy(collision.gameObject);
        //health--;

        //if (health <= 0)
        //{
        //Destroy(gameObject);
        //}
        //} 
    }

    void Update()
    {
        /*if (superMetreCharge == 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                float delay = .4f;

                if (superMetreCharge == 0)
                {
                    Newanimator.Play("AverageJoe_Super");
                    delay = .7f;
                    StartCoroutine(DoSpecialAttack(delay));
                    superMetreCharge = 1f;
                }
                else
                {
                    return;
                }
            }
        }*/

    }
    IEnumerator Stunned()
    {
        Newanimator.Play("Dababy_Hit");
        GetComponent<Dababy_PlayerController2D>().isAttackLocked = true;
        GetComponent<Dababy_PlayerController2D>().isDirectionalAttackLocked = true;
        GetComponent<Dababy_PlayerController2D>().isMoving = true;
        yield return new WaitForSeconds(0.5f);
        Newanimator.Play("Dababy_Idle");
        GetComponent<Dababy_PlayerController2D>().isAttackLocked = false;
        GetComponent<Dababy_PlayerController2D>().isDirectionalAttackLocked = false;
        GetComponent<Dababy_PlayerController2D>().isMoving = false;
    }

    /*IEnumerator DoSpecialAttack(float delay)
    {
        //attackHitbox.SetActive(true);
        attackHitboxSpecial.SetActive(true);
        attackHitboxSpecial2.SetActive(true);
        attackHitboxSpecial3.SetActive(true);
        attackHitboxSpecial4.SetActive(true);
        attackHitboxSpecial5.SetActive(true);
        attackHitboxSpecial6.SetActive(true);
        attackHitboxSpecial7.SetActive(true);
        yield return new WaitForSeconds(.4f);
        //attackHitbox.SetActive(false);
        attackHitboxSpecial.SetActive(false);
        attackHitboxSpecial2.SetActive(false);
        attackHitboxSpecial3.SetActive(false);
        attackHitboxSpecial4.SetActive(false);
        attackHitboxSpecial5.SetActive(false);
        attackHitboxSpecial6.SetActive(false);
        attackHitboxSpecial7.SetActive(false);
        //isAttacking = false;*/
}
