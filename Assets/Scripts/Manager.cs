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
    public int ammo;
    public int skin;

    public Slider slider;

    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI cherryText;
    public TextMeshProUGUI ammoAmount;

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

        if(!PlayerPrefs.HasKey("skin")) {
            PlayerPrefs.SetInt("skin", 0);
            skin = 0;
        }
        else {
            skin = PlayerPrefs.GetInt("skin");
        }

        if(!PlayerPrefs.HasKey("health")) {
            PlayerPrefs.SetInt("health", 100);
            health = 100;
            
        }
        else {
            health = PlayerPrefs.GetInt("health");
        }

        if(!PlayerPrefs.HasKey("ammo")) {
            PlayerPrefs.SetInt("ammo", 3);
            ammo = 3;
            
        }
        else {
            ammo = PlayerPrefs.GetInt("ammo");
        }

        SetMaxHealth(health, 100);
        cherryText.text = cherry.ToString();
        ammoAmount.text = ammo.ToString();
        healthAmount.text = health.ToString();

    }

    public void addcherry() {
        cherry ++;
        cherryText.text = cherry.ToString();
    }

    public void healthpotion() {
        health += 20;
        if (health > 100) {
            health = 100;
            SetHealth(100);
        }
        healthAmount.text = health.ToString();
        SetHealth(health);
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

    public void ammoLose() {
        ammo--;
        ammoAmount.text = ammo.ToString();
    }


    public void savedata(){
        PlayerPrefs.SetInt("cherry", cherry);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("ammo", ammo);
    }

    public void deleteData() {
        int skindata;
         if(!PlayerPrefs.HasKey("skin")) {
            skindata = 0;
        }
        else {
            skindata = PlayerPrefs.GetInt("skin");
        }
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("skin", skindata);
    }
}
