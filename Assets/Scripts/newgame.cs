﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{

    public void newGame() {
        SceneManager.LoadScene("scene 3");
    }

    public void Exit() {
        Application.Quit();
    }
}