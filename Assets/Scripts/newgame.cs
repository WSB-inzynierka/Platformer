using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{

    public void newGame() {
        SceneManager.LoadScene("Scene 1");
    }

    public void Exit() {
        Application.Quit();
    }
}