using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transit;
    public AudioClass audioClass;

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
            audioClass.PlayMusic2();
            collision.gameObject.GetComponent<PlayerController>().manager.savedata();

            scenechange(scenename);
        }
    }

    IEnumerator LoadLevel()
    {
        transit.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
