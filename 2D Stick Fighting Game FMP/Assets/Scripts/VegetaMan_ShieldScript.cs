using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetaMan_ShieldScript : MonoBehaviour
{
    public GameObject vegetaManShield;
    private bool activeShield;
    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        vegetaManShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (!activeShield)
            {
                vegetaManShield.SetActive(true);
                activeShield = true;
                GetComponent<VegetaManPlayerController2D>().isMoving = true;
                GetComponent<VegetaManPlayerController2D>().isAttackLocked = true;
                GetComponent<VegetaManPlayerController2D>().isMoving = true;
                GetComponent<VegetaManPlayerController2D>().isDirectionalAttackLocked = true;
            }
            else
            {
                vegetaManShield.SetActive(false);
                activeShield = false;
                GetComponent<VegetaManPlayerController2D>().isMoving = false;
                GetComponent<VegetaManPlayerController2D>().isAttackLocked = false;
                GetComponent<VegetaManPlayerController2D>().isMoving = false;
                GetComponent<VegetaManPlayerController2D>().isDirectionalAttackLocked = false;
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
