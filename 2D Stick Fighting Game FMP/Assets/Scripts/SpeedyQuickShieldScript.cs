using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyQuickShieldScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (!activeShield)
            {
                Shield.SetActive(true);
                activeShield = true;
                GetComponent<SpeedyQuickController2D>().isMoving = true;
                GetComponent<SpeedyQuickController2D>().isAttackLocked = true;
                GetComponent<SpeedyQuickController2D>().isMoving = true;
                GetComponent<SpeedyQuickController2D>().isDirectionalAttackLocked = true;
            }
            else
            {
                Shield.SetActive(false);
                activeShield = false;
                GetComponent<SpeedyQuickController2D>().isMoving = false;
                GetComponent<SpeedyQuickController2D>().isAttackLocked = false;
                GetComponent<SpeedyQuickController2D>().isMoving = false;
                GetComponent<SpeedyQuickController2D>().isDirectionalAttackLocked = false;
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