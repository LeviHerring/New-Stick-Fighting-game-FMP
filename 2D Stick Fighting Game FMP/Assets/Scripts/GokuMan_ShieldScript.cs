using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuMan_ShieldScript : MonoBehaviour
{

    public GameObject GokuManShield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        GokuManShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!activeShield)
            {
                GokuManShield.SetActive(true);
                activeShield = true;
                GetComponent<GokuMan_PlayerController2D>().isMoving = true;
                GetComponent<GokuMan_PlayerController2D>().isAttackLocked = true;
                GetComponent<GokuMan_PlayerController2D>().isMoving = true;
                GetComponent<GokuMan_PlayerController2D>().isDirectionalAttackLocked = true;
            }
            else
            {
                GokuManShield.SetActive(false);
                activeShield = false;
                GetComponent<GokuMan_PlayerController2D>().isMoving = false;
                GetComponent<GokuMan_PlayerController2D>().isAttackLocked = false;
                GetComponent<GokuMan_PlayerController2D>().isMoving = false;
                GetComponent<GokuMan_PlayerController2D>().isDirectionalAttackLocked = false;
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
