using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fall : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision) {
       if (collision.gameObject.tag == "Player") {

           PermamentUI.perm.Reset();

           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
   } 
}
