using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeGranpa_HealthScript : MonoBehaviour
{
    Animator Newanimator;

    public Image healthImage;
    public GameObject gameOver;
    public Image superMetreImage;

    private LeGranpa_ShieldScript leGranpaShield;
    public float health = 1f;
    public float superMetreCharge = 1f;

    /*[SerializeField]
    GameObject attackHitboxSpecial;

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
    GameObject attackHitboxSpecial7;*/

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Newanimator = GetComponent<Animator>();
        health = 1f;
        superMetreCharge = 1f;
        healthImage.fillAmount = health;
        gameOver.SetActive(false);


    }

    private void OnEnable()
    {
        leGranpaShield = GetComponent<LeGranpa_ShieldScript>();
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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!leGranpaShield.ActiveShield)
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
            else if (collision.tag == "LightNeutral")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LightLow")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LightHigh")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "LightJump")
            {
                TakeDamage(0.03f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "HeavyNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "HeavyHigh")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "HeavyLow")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "HeavyJump")
            {
                TakeDamage(0.075f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_LightNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_LightLow")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_LightHigh")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_HeavyNeutral")
            {
                TakeDamage(0.15f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_HeavyHigh")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_HeavyLow")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "GokuMan_HeavyJump")
            {
                TakeDamage(0.045f);
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
            else if (collision.tag == "Speaman_LightNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_LightLow")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_LightHigh")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_HeavyNeutral")
            {
                TakeDamage(0.15f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_HeavyHigh")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_HeavyLow")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Speaman_HeavyJump")
            {
                TakeDamage(0.045f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }


            else if (collision.tag == "Dababy_LightNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_LightLow")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_LightHIGH")
            {
                TakeDamage(0.055f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_LightJump")
            {
                TakeDamage(0.02f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_HeavyNeutral")
            {
                TakeDamage(0.15f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_HeavyHigh")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_HeavyLow")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            else if (collision.tag == "Dababy_HeavyJump")
            {
                TakeDamage(0.045f);
                SuperMeter(0.1f);
                StartCoroutine(Stunned());
            }
            //else if (collision.tag == "Player2_Grab")
            //{
            //TakeDamage(0.07f);
            //}

            else if (collision.tag == "Bullet")
            {
                Destroy(collision.gameObject);
                TakeDamage(0.05f);
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
                SceneManager.LoadScene(3);
                health = 1f;

            }
            else if (leGranpaShield.ActiveShield)
            {
                if (collision.tag == "Bullet2")
                {
                    Destroy(collision.gameObject);
                    TakeDamage(0.004f);
                }

                else if (collision.tag == "LightNeutral")
                {
                    TakeDamage(0.0002f);
                }
                else if (collision.tag == "LightLow")
                {
                    TakeDamage(0.00025f);
                }
                else if (collision.tag == "LightHigh")
                {
                    TakeDamage(0.00025f);
                }
                else if (collision.tag == "LightJump")
                {
                    TakeDamage(0.0003f);
                }
                else if (collision.tag == "HeavyNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "HeavyHigh")
                {
                    TakeDamage(0.0006f);
                }
                else if (collision.tag == "HeavyLow")
                {
                    TakeDamage(0.0006f);
                }
                else if (collision.tag == "HeavyJump")
                {
                    TakeDamage(0.00075f);
                }

                else if (collision.tag == "Speaman_LightNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_LightLow")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_LightHigh")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_LightJump")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_HeavyNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_HeavyHigh")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_HeavyLow")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "Speaman_HeavyJump")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "GokuMan_LightNeutral")
                {
                    TakeDamage(0.0005f);
                }
                else if (collision.tag == "GokuMan_LightLow")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "GokuMan_LightHigh")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "GokuMan_LightJump")
                {
                    TakeDamage(0.0002f);
                }
                else if (collision.tag == "GokuMan_HeavyNeutral")
                {
                    TakeDamage(0.00015f);
                }
                else if (collision.tag == "GokuMan_HeavyHigh")
                {
                    TakeDamage(0.0007f);
                }
                else if (collision.tag == "GokuMan_HeavyLow")
                {
                    TakeDamage(0.0007f);
                }
                else if (collision.tag == "GokuMan_HeavyJump")
                {
                    TakeDamage(0.00045f);
                }


                else if (collision.tag == "Dababy_LightNeutral")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_LightLow")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_LightHIGH")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_LightJump")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_HeavyNeutral")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_HeavyHigh")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_HeavyLow")
                {
                    TakeDamage(0.00055f);
                }
                else if (collision.tag == "Dababy_HeavyJump")
                {
                    TakeDamage(0.00055f);
                }

            }


        }


        /*void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                float delay = .4f;

                if (superMetreCharge == 0)
                {
                    Newanimator.Play("Player2_Super");
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
            //isAttacking = false;
        }*/

        IEnumerator Stunned()
        {
            Newanimator.Play("LeGranpa_Hit");
            GetComponent<LeGranpa_PlayerController2D>().isAttackLocked = true;
            GetComponent<LeGranpa_PlayerController2D>().isDirectionalAttackLocked = true;
            GetComponent<LeGranpa_PlayerController2D>().isMoving = true;
            yield return new WaitForSeconds(0.5f);
            Newanimator.Play("LeGranpa_Idle");
            GetComponent<LeGranpa_PlayerController2D>().isAttackLocked = false;
            GetComponent<LeGranpa_PlayerController2D>().isDirectionalAttackLocked = false;
            GetComponent<LeGranpa_PlayerController2D>().isMoving = false;
        }
    }
}
