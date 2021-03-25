using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageJoe_Throw : MonoBehaviour
{
    Animator animator;
    Object bulletRef;


    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("BouncyBall");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.Play("AverageJoe_Throw");
            GameObject Bullet = (GameObject)Instantiate(bulletRef);
            Bullet.transform.position = new Vector3(transform.position.x + .2f, transform.position.y + .1f, -1);
        }
    }
}
