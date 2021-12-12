using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PermamentUI : MonoBehaviour
{
    public int cherries = 0;
    public int health = 5;

    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI cherryText;

    public static PermamentUI perm;

    private void Start() {

        DontDestroyOnLoad(gameObject);

        if (!perm) {
            perm = this;
        }
        else {
            Destroy (gameObject);
        }
    }

    public void Reset(){
        cherries = 0;
        cherryText.text = cherries.ToString();
    }
}

