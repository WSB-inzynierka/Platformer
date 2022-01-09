using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision) {
       if (collision.gameObject.tag == "Player") {
           collision.gameObject.GetComponent<PlayerController>().manager.savedata();
           SceneManager.LoadScene(sceneName);
       }
   } 
}
