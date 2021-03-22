using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Animator animator;
    Object bulletRef;


    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.Play("Player_Shoot");
            GameObject Bullet = (GameObject)Instantiate(bulletRef);
            Bullet.transform.position = new Vector3(transform.position.x + .2f, transform.position.y + .1f, -1);
        }
    }
}
