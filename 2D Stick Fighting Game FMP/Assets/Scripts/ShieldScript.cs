using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    
    public GameObject Shield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        Shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(!activeShield)
            {
                Shield.SetActive(true);
                activeShield = true;
                GetComponent<AverageJoe_PlayerController2D>().isMoving = true;
                GetComponent<AverageJoe_PlayerController2D>().isAttackLocked = true;
                GetComponent<AverageJoe_PlayerController2D>().isMoving = true;
                GetComponent<AverageJoe_PlayerController2D>().isDirectionalAttackLocked = true; 
            }
            else
            {
                Shield.SetActive(false);
                activeShield = false;
                GetComponent<AverageJoe_PlayerController2D>().isMoving = false;
                GetComponent<AverageJoe_PlayerController2D>().isAttackLocked = false;
                GetComponent<AverageJoe_PlayerController2D>().isDirectionalAttackLocked = false; 
            }
        }
    }


    public bool ActiveShield
    {
        get
        {
            return activeShield;
        }
        set
        {
            activeShield = value;
        }
    }
}
