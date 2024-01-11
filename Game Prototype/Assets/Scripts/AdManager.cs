using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    // Variables for referencing the ad controller (initializing script) and ad types
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
        // Do not destroy the AdManager GameObject when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Load the banner ad when the game starts
        bannerAds.LoadBanner();
        // Load the interstitial ad when the game starts
        interstitialAds.LoadAd();
    }
}
