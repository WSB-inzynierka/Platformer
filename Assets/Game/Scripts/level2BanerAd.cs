using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2BanerAd : MonoBehaviour
{

    public GoogleAdMobController googleAdMobController;
    // Start is called before the first frame update
    void Start()
    {
        googleAdMobController.RequestBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
