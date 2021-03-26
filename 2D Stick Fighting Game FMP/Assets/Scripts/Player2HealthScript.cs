using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player2HealthScript : MonoBehaviour
{
    public Image healthImage;
    public GameObject gameOver;

    private Player2ShieldScript Shield;
    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
        healthImage.fillAmount = health;
        gameOver.SetActive(false);
        Shield = GetComponent<Player2ShieldScript>();

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
            else if (collision.tag == "Player2_LightNeutral")
            {
                TakeDamage(0.02f);
            }
            else if (collision.tag == "Player2_LightLow")
            {
                TakeDamage(0.025f);
            }
            else if (collision.tag == "Player2_LightHigh")
            {
                TakeDamage(0.025f);
            }
            else if (collision.tag == "Player2_LightJump")
            {
                TakeDamage(0.03f);
            }
            else if(collision.tag == "Player2_HeavyNeutral")
            {
                TakeDamage(0.05f);
            }
            else if (collision.tag == "Player2_HeavyHigh")
            {
                TakeDamage(0.06f);
            }
            else if (collision.tag == "Player2_HeavyLow")
            {
                TakeDamage(0.06f);
            }
            else if (collision.tag == "Player2_HeavyJump")
            {
                TakeDamage(0.075f);
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
            }
        }

        
    }



}
