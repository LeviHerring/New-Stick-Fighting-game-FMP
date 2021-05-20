using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaman_ShieldScript : MonoBehaviour
{
    public GameObject speamanShield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        speamanShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!activeShield)
            {
                speamanShield.SetActive(true);
                activeShield = true;
                GetComponent<Speaman_PlayerController2D>().isAttackLocked = true;
                GetComponent<Speaman_PlayerController2D>().isDirectionalAttackLocked = true;
                GetComponent<Speaman_PlayerController2D>().isMoving = true;

            }
            else
            {
                speamanShield.SetActive(false);
                activeShield = false;
                GetComponent<Speaman_PlayerController2D>().isAttackLocked = false;
                GetComponent<Speaman_PlayerController2D>().isDirectionalAttackLocked = false;
                GetComponent<Speaman_PlayerController2D>().isMoving = false;
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
