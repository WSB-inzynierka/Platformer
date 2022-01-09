using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public int cherry;
    public int health;

    public Slider slider;

    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI cherryText;

    private void Start() {
        if(SceneManager.GetActiveScene().name == "Scene 3") {
            deleteData();
        }

        if(!PlayerPrefs.HasKey("cherry")) {
            PlayerPrefs.SetInt("cherry", 0);
            cherry = 0;
        }
        else {
            cherry = PlayerPrefs.GetInt("cherry");
        }

        if(!PlayerPrefs.HasKey("health")) {
            PlayerPrefs.SetInt("health", 100);
            health = 100;
            
        }
        else {
            health = PlayerPrefs.GetInt("health");
        }
        SetMaxHealth(health, 100);
        cherryText.text = cherry.ToString();
        healthAmount.text = health.ToString();

    }

    public void addcherry() {
        cherry ++;
        cherryText.text = cherry.ToString();
    }

    public void sethealth(int damage) {
        health -= damage;
        healthAmount.text = health.ToString();
        SetHealth(health);

        if (health <= 0)
        {
            deleteData();
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetMaxHealth(int health, int maxhealth) {
        slider.maxValue = maxhealth;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }


    public void savedata(){
        PlayerPrefs.SetInt("cherry", cherry);
        PlayerPrefs.SetInt("health", health);
    }

    public void deleteData() {
        PlayerPrefs.DeleteAll();
    }
}
