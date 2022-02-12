using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public void SkinChange()
    {
        SceneManager.LoadScene("shop");
    }
}
