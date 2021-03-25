using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletScript : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    int damage;
    [SerializeField]
    float timeToDestroy = 3f;


    public void StartShoot(bool isFacingLeft)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        
        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        
        if (isFacingLeft)
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0);
        }


        Destroy(gameObject, timeToDestroy);

    }

    
}
