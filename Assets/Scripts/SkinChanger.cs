using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;



public class SkinChanger : MonoBehaviour
{
    public void ChangeSkin(int skinName){
        
        PlayerPrefs.SetInt("skin", skinName);
        
    }
}
