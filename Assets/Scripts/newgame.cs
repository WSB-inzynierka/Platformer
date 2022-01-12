using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    Manager manager;

    public void newGame() {
        SceneManager.LoadScene("scene 3", LoadSceneMode.Single);
        manager.deleteData();
    }

}
