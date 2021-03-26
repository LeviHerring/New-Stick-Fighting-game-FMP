using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Image healthImage;
    public GameObject gameOver;

    private ShieldScript Shield;
    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
        healthImage.fillAmount = health;
        gameOver.SetActive(false);
        Shield = GetComponent<ShieldScript>();
        
    }

        void TakeDamage(float amount)
    {
        health -= amount;
        healthImage.fillAmount = health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Shield.ActiveShield)
        {
            if (collision.tag == "Spike")
            {
                TakeDamage(0.1f);
            }
            else if (collision.tag == "Flame")
            {
                TakeDamage(0.5f);
            }
            else if (collision.tag == "Player2 _LightNeutral")
            {
                TakeDamage(0.02f);
            }
            else if (collision.tag == "Player2 _LightLow")
            {
                TakeDamage(0.025f);
            }
            else if (collision.tag == "Player2 _LightHigh")
            {
                TakeDamage(0.025f);
            }
            else if (collision.tag == "Player2 _LightJump")
            {
                TakeDamage(0.03f);
            }
            else if (collision.tag == "Player2 _HeavyNeutral")
            {
                TakeDamage(0.05f);
            }
            else if (collision.tag == "Player2 _HeavyHigh")
            {
                TakeDamage(0.06f);
            }
            else if (collision.tag == "Player2 _HeavyLow")
            {
                TakeDamage(0.06f);
            }
            else if (collision.tag == "Player2 _HeavyJump")
            {
                TakeDamage(0.075f);
            }
            else if (collision.tag == "Player2 _Grab")
            {
                TakeDamage(0.07f);
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
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

         
            
        
    }


   

