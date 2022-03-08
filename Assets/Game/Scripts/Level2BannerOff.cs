using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BannerOff : MonoBehaviour
{

    public GoogleAdMobController googleAdMobController;
    // Start is called before the first frame update
    void Start()
    {
        googleAdMobController.DestroyBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
