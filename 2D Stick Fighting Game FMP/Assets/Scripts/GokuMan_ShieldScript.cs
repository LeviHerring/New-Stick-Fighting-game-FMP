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
            }
            else
            {
                GokuManShield.SetActive(false);
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
