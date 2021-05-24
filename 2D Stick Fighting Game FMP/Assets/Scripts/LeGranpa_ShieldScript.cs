using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeGranpa_ShieldScript : MonoBehaviour
{
    public GameObject leGranpaShield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        leGranpaShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (!activeShield)
            {
                leGranpaShield.SetActive(true);
                activeShield = true;
                GetComponent<LeGranpa_PlayerController2D>().isAttackLocked = true;
                GetComponent<LeGranpa_PlayerController2D>().isMoving = true;
                GetComponent<LeGranpa_PlayerController2D>().isDirectionalAttackLocked = true;
            }
            else
            {
                leGranpaShield.SetActive(false);
                activeShield = false;
                GetComponent<LeGranpa_PlayerController2D>().isAttackLocked = false;
                GetComponent<LeGranpa_PlayerController2D>().isMoving = false;
                GetComponent<LeGranpa_PlayerController2D>().isDirectionalAttackLocked = false;
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
