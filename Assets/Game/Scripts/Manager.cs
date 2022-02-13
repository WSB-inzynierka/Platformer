using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int Coin;
    public int health;
    public int Mana;
    public int skin;
    public int Currency;
    public int skin2Cost = 20;
    public int skin3Cost = 50;
    public int projectile;
    public int HighScore;

    public Slider slider;
    public Slider Manaslider;

    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI cherryText;
    public TextMeshProUGUI ManaAmount;

    private void Awake() {
        if(SceneManager.GetActiveScene().name == "Scene 1") {
            deleteData2();

        }

        if(!PlayerPrefs.HasKey("Coin")) {
            PlayerPrefs.SetInt("Coin", 0);
            Coin = 0;
        }
        else {
            Coin = PlayerPrefs.GetInt("Coin");
        }

        if(!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetInt("HighScore", 0);
            HighScore = 0;
        }
        else {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
        
        if(!PlayerPrefs.HasKey("Elder Coins")) {
            PlayerPrefs.SetInt("Elder Coins", 0);
            Currency = 0;
        }
        else {
            Currency = PlayerPrefs.GetInt("Currency");
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

        if(!PlayerPrefs.HasKey("Mana")) {
            PlayerPrefs.SetInt("Mana", 30);
            Mana = 30;
            
        }
        else {
            Mana = PlayerPrefs.GetInt("Mana");
        }

        if(!PlayerPrefs.HasKey("skin2Cost")) {
            PlayerPrefs.SetInt("skin2Cost", 10);
            skin2Cost = 10;
            
        }
        else {
            skin2Cost = PlayerPrefs.GetInt("skin2Cost");
        }

        if(!PlayerPrefs.HasKey("skin3Cost")) {
            PlayerPrefs.SetInt("skin3Cost", 10);
            skin3Cost = 10;
            
        }
        else {
            skin3Cost = PlayerPrefs.GetInt("skin3Cost");
        }

        if(!PlayerPrefs.HasKey("projectile")) {
            PlayerPrefs.SetInt("projectile", 0);
            projectile = 0;
            
        }
        else {
            projectile = PlayerPrefs.GetInt("projectile");
        }



        if(SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Shop") {
            SetMaxHealth(health, 100);
            SetMaxMana(Mana, 100);
            cherryText.text = Coin.ToString();
            ManaAmount.text = Mana.ToString();
            healthAmount.text = health.ToString();
        }
    }

    public void addcherry() {
        Coin ++;
        cherryText.text = Coin.ToString();
    }

    public void healthpotion() {
        health += 20;
        if (health > 100) {
            health = 100;
            PlayerPrefs.SetInt("health", health);
            SetHealth(100);
        }
        healthAmount.text = health.ToString();
        SetHealth(health);
    }

    public void ManaPotion() {
        Mana += 10;
        if (Mana > 100) {
            Mana = 100;
            PlayerPrefs.SetInt("Mana", Mana);
        }
        ManaAmount.text = Mana.ToString();
        SetMana(Mana);
    }

    public void sethealth(int damage) {
        health -= damage;
        healthAmount.text = health.ToString();
        SetHealth(health);
        PlayerPrefs.SetInt("health", health);

        if (health <= 0)
        {
            if (Coin >= HighScore) {
                HighScore = Coin;
                PlayerPrefs.SetInt("HighScore", HighScore);
            }            
            deleteData2();
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetMaxHealth(int health, int maxhealth) {
        slider.maxValue = maxhealth;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }

    public void SetMaxMana(int Mana, int maxMana) {
        Manaslider.maxValue = 100;
        Manaslider.value = Mana;
    }

    public void SetMana(int Mana) {
        Manaslider.value = Mana;
    }

    public void ManaLose() {
        Mana -= 10;
        ManaAmount.text = Mana.ToString();
        SetMana(Mana);
    }

    public void savedata(){
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("Mana", Mana);
    }

    // public void deleteData() {
    //     int skindata;
    //     if(!PlayerPrefs.HasKey("skin")) {
    //         skindata = 0;
    //     }
    //     else {
    //         skindata = PlayerPrefs.GetInt("skin");
    //     }
        
    //     PlayerPrefs.DeleteAll();
    //     PlayerPrefs.SetInt("skin", skindata);
    // }
    
    public void deleteData2() {
        PlayerPrefs.DeleteKey("Mana");
        PlayerPrefs.DeleteKey("health");
        PlayerPrefs.DeleteKey("Coin");
    } 
}