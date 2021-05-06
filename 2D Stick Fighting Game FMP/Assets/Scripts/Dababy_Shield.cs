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
            }
            else
            {
                dababyShield.SetActive(false);
                activeShield = false;
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
