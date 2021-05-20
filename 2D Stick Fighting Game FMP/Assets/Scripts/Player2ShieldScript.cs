using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ShieldScript : MonoBehaviour
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
                GetComponent<Player2Controller>().isAttackLocked = true;
                GetComponent<Player2Controller>().isDirectionalAttackLocked = true;
                GetComponent<Player2Controller>().isMoving = true;
            }
            else
            {
                Shield.SetActive(false);
                activeShield = false;
                GetComponent<Player2Controller>().isAttackLocked = false;
                GetComponent<Player2Controller>().isDirectionalAttackLocked = false;
                GetComponent<Player2Controller>().isMoving = false;
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
