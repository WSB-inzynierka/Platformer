using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;



public class SkinChanger : MonoBehaviour
{
    public Manager manager;
    public Weapon weapon;

    [Header("Skin2")]
    public Button skin2;
    public TextMeshProUGUI skin2PurchasedText;

    [Header("Skin3")]
    public Button skin3;
    public TextMeshProUGUI skin3PurchasedText;

    public TextMeshProUGUI currencyAmount;

    private void Start() {
        manager = GetComponent<Manager>();

        if(!PlayerPrefs.HasKey("skin2PurchasedText")) {
            PlayerPrefs.SetString("skin2PurchasedText", manager.skin2Cost.ToString());
            skin2PurchasedText.text = "20 monet";
        }
        else {
            skin2PurchasedText.text = PlayerPrefs.GetString("skin2PurchasedText");
        }
        
        if(!PlayerPrefs.HasKey("skin3PurchasedText")) {
            PlayerPrefs.SetString("skin3PurchasedText", manager.skin3Cost.ToString());
            skin3PurchasedText.text = "50 monet";
        }
        else {
            skin3PurchasedText.text = PlayerPrefs.GetString("skin3PurchasedText");
        }
        
        manager.Currency = PlayerPrefs.GetInt("Currency", manager.Currency);
        currencyAmount.text = manager.Currency.ToString(); 

        manager.skin2Cost = PlayerPrefs.GetInt("skin2Cost", manager.skin2Cost);
        skin2PurchasedText.text = PlayerPrefs.GetString("skin2PurchasedText", skin2PurchasedText.text);

        manager.skin3Cost = PlayerPrefs.GetInt("skin3Cost", manager.skin3Cost);
        skin3PurchasedText.text = PlayerPrefs.GetString("skin3PurchasedText", skin3PurchasedText.text);

        CostCheck();

        TextChange();    
    }

    public void TextChange() {
        if (manager.skin2Cost == 0) {
            skin2PurchasedText.text = "Purchased";
        }
        else {
            skin2PurchasedText.text = "20 gold";
        }

        if (manager.skin3Cost == 0) {
            skin3PurchasedText.text = "Purchased";
        }
        else {
            skin3PurchasedText.text = "50 gold";
        }
    }

    private void CostCheck()
    {
        if (manager.Currency >= manager.skin2Cost)
        {
            skin2.interactable = true;
        }
        else
        {
            skin2.interactable = false;
        }

        if (manager.Currency >= manager.skin3Cost)
        {
            skin3.interactable = true;
        }
        else
        {
            skin3.interactable = false;
        }
    }



    public void Skin2Buy() {
        manager.Currency -= manager.skin2Cost;
        currencyAmount.text = manager.Currency.ToString(); 
        PlayerPrefs.SetInt("Currency", manager.Currency);
        manager.skin2Cost = 0;
        skin2PurchasedText.text = "Purchased";
        PlayerPrefs.SetInt("skin2Cost", manager.skin2Cost);
        CostCheck();
    }

    

    public void Skin3Buy() {
        manager.Currency -= manager.skin3Cost;
        PlayerPrefs.SetInt("Currency", manager.Currency);
        currencyAmount.text = manager.Currency.ToString(); 
        manager.skin3Cost = 0;
        skin3PurchasedText.text = "Purchased";
        PlayerPrefs.SetInt("skin3Cost", manager.skin3Cost);
        CostCheck();

    }

    public void WatchAd() {
        manager.Currency++;
        PlayerPrefs.SetInt("Currency", manager.Currency);
        currencyAmount.text = manager.Currency.ToString();
        CostCheck();
    }

    public void skinchange(int skinName) {
        PlayerPrefs.SetInt("skin", skinName);
    }
}
