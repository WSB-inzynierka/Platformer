using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;



public class SkinChanger : MonoBehaviour
{

    public Manager manager;
    public Button skin2;
    public bool skin2purchased = false;
    public Button skin3;
    public bool skin3purchased = false;

    
    public TextMeshProUGUI currencyAmount;

    private void Start() {
        manager = GetComponent<Manager>();
        PlayerPrefs.GetInt("Currency", manager.Currency);
        currencyAmount.text = manager.Currency.ToString();
    }
    private void Update() {
        if (manager.Currency >= 20 && skin2purchased == false) {
            skin2.interactable = true;
        }
        else {
            skin2.interactable = false;
        }

        if (manager.Currency >= 50 && skin3purchased == false) {
            skin3.interactable = true;
        }
        else {
            skin3.interactable = false;
        }
    }

    public void ChangeSkin(int skinName){
        PlayerPrefs.SetInt("skin", skinName);
    }

    public void WatchAd() {
        manager.Currency++;
        PlayerPrefs.SetInt("Currency", manager.Currency);
        currencyAmount.text = manager.Currency.ToString();
    }
}
