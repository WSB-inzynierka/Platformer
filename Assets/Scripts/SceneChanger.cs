using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    Manager manager;
    public string scenename;

    public void scenechange() {
        SceneManager.LoadScene(scenename, LoadSceneMode.Additive);
    }
}
