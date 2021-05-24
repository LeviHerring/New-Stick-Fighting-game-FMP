using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dababy_Shield : MonoBehaviour
{
    public GameObject dababyShield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        dababyShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!activeShield)
            {
                dababyShield.SetActive(true);
                activeShield = true;
                GetComponent<Dababy_PlayerController2D>().isAttackLocked = true;
                GetComponent<Dababy_PlayerController2D>().isMoving = true;
                GetComponent<Dababy_PlayerController2D>().isDirectionalAttackLocked = true;
            }
            else
            {
                dababyShield.SetActive(false);
                activeShield = false;
                GetComponent<Dababy_PlayerController2D>().isAttackLocked = false;
                GetComponent<Dababy_PlayerController2D>().isMoving = false;
                GetComponent<Dababy_PlayerController2D>().isDirectionalAttackLocked = false;
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
