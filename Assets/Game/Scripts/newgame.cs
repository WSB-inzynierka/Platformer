using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    public Manager manager;

    public GoogleAdMobController googleAdMobController;

    public TextMeshProUGUI HighScoreText;

    private void Start() {
        HighScoreText.SetText(manager.HighScore.ToString());
    }

    public void newGame() {
        SceneManager.LoadScene("Scene 1");
    }

    public void Exit() {
        Application.Quit();
    }
    
}