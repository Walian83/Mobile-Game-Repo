using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider volumeSlider = null;

    public TMP_Text volumeTextUI = null;    

    private void Start()
    {
        LoadValues();
        AdManager.instance.bannerAds.HideBannerAd();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void PlayGame()
    {
        AdManager.instance.bannerAds.ShowBannerAd();
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
