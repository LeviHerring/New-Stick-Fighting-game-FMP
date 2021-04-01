﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuFunction()
    {
        SceneManager.LoadScene(0);
    }
}
