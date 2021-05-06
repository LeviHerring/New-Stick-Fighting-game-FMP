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
            }
            else
            {
                speamanShield.SetActive(false);
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
