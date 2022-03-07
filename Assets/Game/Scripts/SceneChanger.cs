using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transit;
    public test test;

    public Manager manager;

    public float transitionTime = 1f;
    public string scenename;

    public void scenechange(string scenename)
    {
        //SceneManager.LoadScene(scenename);
        StartCoroutine(LoadLevel());
        SceneManager.LoadScene(scenename);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            test.PlayMusic();
            collision.gameObject.GetComponent<PlayerController>().manager.savedata();

            if (manager.Coin >= manager.HighScore) {
                manager.HighScore = manager.Coin;
                PlayerPrefs.SetInt("HighScore", manager.HighScore);
            }            

            scenechange(scenename);
        }
    }

    IEnumerator LoadLevel()
    {
        transit.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
