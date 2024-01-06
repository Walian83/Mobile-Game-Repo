using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public UnityAdController controller;
    public BannerAd bannerAds;
    public InterstitialAd interstitialAds;

    public static AdManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        bannerAds.LoadBanner();
        interstitialAds.LoadAd();
    }
}
