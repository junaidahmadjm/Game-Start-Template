using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Drawing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.Networking;
public class MainMenuScript : MonoBehaviour
{
    [Header("--------------- [Main Menu Screens / Panels] ---------------")]
    [Space(10)]
    public GameObject MainMenuScreen;
    public GameObject ModeSelectionScreen;
    public GameObject VehicleSelectionScreen;
    public GameObject LevelSelectionScreen;
    public GameObject SettingScreen;
    public GameObject StoreScreen;
    public GameObject LoadingScreen;

    [Header("--------------- [Buttons] ---------------")]
    [Space(10)]
    public Button PlayButton;
    public Button MoreGamesButton;
    public Button RateUsButton;
    public Button PrivacyPolicyButton;
    public Button SettingsButton;
    public Button UnlockEverythingButton;
    public Button StoreButton;

    [Header("--------------- [Texts] ---------------")]
    [Space(10)]
    public Text CoinsText;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        
    }
    private void Start()
    {
        MainMenuScreen.SetActive(true);
    }

    public void PlayButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        MainMenuScreen.SetActive(false);
        ModeSelectionScreen.SetActive(true);
    }
    public void SettingsButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        SettingScreen.SetActive(true);
    }
    public void StoreButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        StoreScreen.SetActive(true);
    }
    public void RateUsButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        Application.OpenURL("");
    }
    public void PrivacyPolicyButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        Application.OpenURL("");
    }
    public void MoreGamesButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        Application.OpenURL("");
    }
    public void ModeButtonClicked(int ModeNo)
    {
        SoundManager.instance?.ButtonClickSound();
        Constant.currentMode = ModeNo;
        ModeSelectionScreen.SetActive(false);
        LevelSelectionScreen.SetActive(true);
    }
    public void ModeBackButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        ModeSelectionScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }
    public void LevelSelectionBackButton()
    {
        SoundManager.instance?.ButtonClickSound();
        LevelSelectionScreen.SetActive(false);
        ModeSelectionScreen.SetActive(true);
    }
    public void LevelButtonPressed()
    {
        SoundManager.instance?.ButtonClickSound();
        LevelSelectionScreen.SetActive(false);
        VehicleSelectionScreen.SetActive(true);
    }
}
