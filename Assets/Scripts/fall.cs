using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class fall : MonoBehaviour
{

    public Manager manager;

    public GameObject Player;
    

   private void OnTriggerEnter2D(Collider2D collision) {
       if (collision.gameObject.tag == "Player") {

           manager.sethealth(20);
           Player.transform.position = new Vector3 (-3f, 2f, 0f);

        //    collision.gameObject.GetComponent<PlayerController>().manager.deleteData2();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
   } 
}
