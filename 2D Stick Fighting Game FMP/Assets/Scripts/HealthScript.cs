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

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
            }
        }

        if (collision.CompareTag("Bullet)"))
        {
            Destroy(collision.gameObject);
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        } 
    }

         
            
        
    }


   

