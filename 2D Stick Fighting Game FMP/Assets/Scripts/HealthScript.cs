using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthScript : MonoBehaviour
{
    Animator Newanimator; 

    public Image healthImage;
    public GameObject gameOver;
    public Image superMetreImage; 

    private ShieldScript Shield;
    public float health = 1f;
    public float superMetreCharge = 1f;

    [SerializeField]
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
    GameObject attackHitboxSpecial7;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Newanimator = GetComponent<Animator>();
        health = 1f;
        superMetreCharge = 1f;
        healthImage.fillAmount = health;
        gameOver.SetActive(false);
        Shield = GetComponent<ShieldScript>();
        
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
        if (!Shield.ActiveShield)
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
            }
            else if (collision.tag == "Player2_LightLow")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2 _LightHigh")
            {
                TakeDamage(0.025f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2 _LightJump")
            {
                TakeDamage(0.03f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2_HeavyNeutral")
            {
                TakeDamage(0.05f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2_HeavyHigh")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2_HeavyLow")
            {
                TakeDamage(0.06f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2_HeavyJump")
            {
                TakeDamage(0.075f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Player2 _Grab")
            {
                TakeDamage(0.07f);
                SuperMeter(0.1f);
            }
            else if (collision.tag == "Bullet2")
            {
                Destroy(collision.gameObject);
                TakeDamage(0.05f);
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
                SceneManager.LoadScene(4);
                health = 1f;
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
    }

    IEnumerator DoSpecialAttack(float delay)
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
    }


}


   

