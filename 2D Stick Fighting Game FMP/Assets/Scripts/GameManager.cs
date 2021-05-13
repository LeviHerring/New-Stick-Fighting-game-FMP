using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerOne;

    [SerializeField]
    GameObject PlayerTwo;

    [SerializeField]
    GameObject SpeedyQuick;

    [SerializeField]
    GameObject Speaman;

    [SerializeField]
    GameObject GokuMan;

    [SerializeField]
    GameObject VegetaMan;

    [SerializeField]
    GameObject Dababy;

    [SerializeField]
    GameObject LeGranpa;



    
    // Start is called before the first frame update
    void Start()
    {
        string Player = PlayerPrefs.GetString("Player");
        string Player2 = PlayerPrefs.GetString("Player2");

        if (Player == "PlayerOne")
        {
            PlayerOne.SetActive(true);
        }

        switch (Player)
        {
            case "PlayerOne":
                PlayerOne.SetActive(true);
                break;
            case "Speaman":
                Speaman.SetActive(true);
                break;
            case "GokuMan":
                GokuMan.SetActive(true);
                break;
            case "Dababy":
                Dababy.SetActive(true);
                break;
        }

        switch (Player2)
        {
            case "PlayerTwo":
                PlayerTwo.SetActive(true);
                break;
            case "SpeedyQuick":
                SpeedyQuick.SetActive(true);
                break;
            case "VegetaMan":
                VegetaMan.SetActive(true);
                break;
            case "LeGranpa":
                LeGranpa.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
