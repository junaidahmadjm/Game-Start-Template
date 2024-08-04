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

public class GameplayScript : MonoBehaviour
{
    [Header("------------------- [Gameplay Script] -------------------")]
    [Space(10)]

    // Check true on editor if you want to create new or test levels in same gameplay scene.
    public bool isTestMode = false;
    public int LevelNo;
    public int ModeNumber;
    public int VehicleNo;

    [Header("-------------------- [Environment] --------------------")]
    [Space(10)]
    public GameObject Environment;
    [Header("--------------- [Gameplay Screens / Panels] ---------------")]
    [Space(10)]
    public GameObject LevelCompleteScreen;
    public GameObject LevelFailScreen;
    public GameObject LevelPauseScreen;
    public GameObject LoadingScreen;
    public GameObject ObjectivePanel;
    [Header("--------------- [Vehicles] ---------------")]
    [Space(10)]
    public GameObject[] Vehicles;

    [Header("---------------------- [Levels] ----------------------")]
    [Space(10)]
    public GameObject[] CareerModeLevels;

    [Header("--------------------- [Buttons / Texts] ---------------------")]
    [Space(10)]
    public Button TwoXRewardButton;
    public Text LevelNoText;



    private void OnEnable()
    {
        Environment?.SetActive(true);
        ObjectivePanel?.SetActive(true);
        foreach (var item in CareerModeLevels)
        {
            if (item)
                item.SetActive(false);
        }
        foreach (var item in Vehicles)
        {
            if (item)
                item.SetActive(false);
        }
#if UNITY_EDITOR
        if(isTestMode)
        {
            Constant.currentLevel = LevelNo;
            Constant.currentMode = ModeNumber;
            Constant.currentCharacter = VehicleNo;
        }
        if(!isTestMode)
        {
            LevelNo = Constant.currentLevel;
            ModeNumber = Constant.currentMode;
            VehicleNo = Constant.currentCharacter;
        }
#endif
#if !UNITY_EDITOR
            LevelNo = Constant.currentLevel;
            ModeNumber = Constant.currentMode;
            VehicleNo = Constant.currentCharacter;
#endif
        if(LevelNoText)
        {
            LevelNoText.text = "Level No. " + LevelNo;
        }
        if(ModeNumber==1)
        {
            CareerModeLevels[LevelNo].SetActive(true);
        }
        Vehicles[Constant.currentCharacter].SetActive(true);

    }
    private void Start()
    {
        
    }
    public void LevelPause()
    {
        Time.timeScale = 0.00001f;
        LevelPauseScreen.SetActive(true);
    }
    public void LevelComplete()
    {
        Time.timeScale = 0.00001f;

        LevelCompleteScreen.SetActive(true);


    }
    public void LevelFailed()
    {
        Time.timeScale = 0.00001f;
        LevelFailScreen.SetActive(false);

    }

    /*-----------------------------------Objective Panel Okay button-----------------------------------*/
    public void OkayButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();

        ObjectivePanel.SetActive(false);
        if(GameManager.instance)
        {
            if(GameManager.instance.levelController.isCutsceneOnStart)
            {
                GameManager.instance?.levelController?.PlayCutScene(0);
            }
            else
            {
                // Write functionality if you dont want cutscene on start like start engine button
            }
        }
    }

    /*-----------------------------------Ad Callings---------------------------------*/
    void showBanner()
    {

    }
    void showBigBanner()
    {

    }
    void showInterstital()
    {

    }
}
