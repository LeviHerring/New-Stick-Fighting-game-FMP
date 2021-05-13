using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScreenButton : MonoBehaviour
{

    public string playerOne;
    public string playerTwo; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Character()
    {
        switch (GameObject.Find("RedSelect").GetComponent<RedSelector>().numberPosPlayerTwo)
        {
            case 0:
                //playerTwo = "AverageJoePlayer2";
                PlayerPrefs.SetString("Player2", "PlayerTwo");
                break;
            case 1:
                //playerTwo = "SpeedyQuick";
                PlayerPrefs.SetString("Player2", "SpeedyQuick");
                break;
            case 2:
                //playerTwo = "VegetaMan";
                PlayerPrefs.SetString("Player2", "VegetaMan");
                break;
            case 3:
                //playerTwo = "LeGranpa";
                PlayerPrefs.SetString("Player2", "LeGranpa");
                break;
        }

        switch (GameObject.Find("BlueSelect").GetComponent<BlueSelector>().numberPosPlayerOne)
        {
            case 3:
                //playerOne = "AverageJoePlayer1";
                PlayerPrefs.SetString("Player", "PlayerOne");
                break;
            case 2:
                //playerOne = "Speaman";
                PlayerPrefs.SetString("Player", "Speaman");
                break;
            case 1:
                //playerOne = "GokuMan";
                PlayerPrefs.SetString("Player", "GokuMan");
                break;
            case 0:
                //playerOne = "Dababy";
                PlayerPrefs.SetString("Player", "Dababy");
                break;
        }

        SceneManager.LoadScene(2);
        
    }
}
