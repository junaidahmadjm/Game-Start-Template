using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{
    [Header("----------- [Mode Selection (Locking / Unlocking)] -----------")]
    [Header("----------------[Select the option]----------------")]
    [Space(10)]
    public bool OpenAllModes;
    public bool UnlockModeUsingLevel;
    public bool UnlockModeUsingWatchAd;

    [Header("----------- [Mode Buttons and Locks] -----------")]
    [Space(10)]
    public GameObject[] ModeButtons;
    public GameObject[] Locks;
    public GameObject[] UnlockModeButton;

    // These are no. of levels required for each mode to unlock next mode.
    [Header("---------- [No of levels required to unlock next mode] ----------")]
    public int[] ModeLevels = { 1, 1, 5, 7, 9 };

    private void OnEnable()
    {
        unlockAllModes();
        unlockMode();
        unlockModeWatchAd();
        unlockFirstMode();
        checkModes();

    }

    /*-----------------------------------If Open All Modes check is true-------------------------------------*/
    private void unlockAllModes()
    {
        if(OpenAllModes)
        {
            foreach (var item in Locks)
            {
                item.SetActive(false);
            }
            foreach (var item in ModeButtons)
            {
                item.SetActive(true);
            }
        }
    }

    /*-----------------------------------If Unlock Mode using level is true-------------------------------------*/
    private void unlockMode()
    {
        if(UnlockModeUsingLevel)
        {
            for(int i=1;i<ModeLevels.Length;i++)
            {
                //Debug.Log("up" + i);
                for(int j=1;j<=ModeLevels[i];j++)
                {
                    //Debug.Log(i+ " " + j);
                    if(PlayerPrefs.GetInt(Constant.unlockedLevel+i+j)==1)
                    {
                        ModeButtons[i].SetActive(true);
                        Locks[i].SetActive(false);
                    }
                    else
                    {
                        ModeButtons[i].SetActive(false);
                        Locks[i].SetActive(true);
                    }
                }
            }
        }
    }

    /*-----------------------------------If Unlock Mode using Watch Ad is true-------------------------------------*/
    private void unlockModeWatchAd()
    {
        if(UnlockModeUsingWatchAd)
        {
            if(PlayerPrefs.GetInt("ModeWatchAd")!=1)
            {
                foreach (var item in UnlockModeButton)
                {
                    if (item)
                        item.SetActive(true);
                }
                PlayerPrefs.SetInt("ModeWatchAd", 1);
            }
            for (int i = 1; i <= ModeLevels.Length; i++)
            {
                for (int j = 1; j <= ModeLevels[i]; j++)
                {
                    if (PlayerPrefs.GetInt(Constant.unlockedLevel + i + j) == 1)
                    {
                        ModeButtons[i].SetActive(true);
                        Locks[i].SetActive(false);
                        UnlockModeButton[i].SetActive(false);
                    }
                    else
                    {
                        ModeButtons[i].SetActive(false);
                        Locks[i].SetActive(true);
                        UnlockModeButton[i].SetActive(true);
                    }
                }
            }
        }
    }
    void unlockFirstMode()
    {
        if (PlayerPrefs.GetInt(Constant.modeNo + 1) == 0)
        {
            PlayerPrefs.SetInt(Constant.modeNo + 1, 1);
        }
    }
    /*-----------------------------------Unlock Mode by Watching Ad-------------------------------------*/
    void checkModes()
    {
        for(int i = 1;i<=ModeButtons.Length;i++)
        {
            if(PlayerPrefs.GetInt(Constant.modeNo + i)==1)
            {
                ModeButtons[i].SetActive(true);
                UnlockModeButton[i].SetActive(false);
                Locks[i].SetActive(false);
            }
        }
    }
    public void unlockModeButton(int Mode)
    {
        SoundManager.instance?.ButtonClickSound();
        Constant.currentMode = Mode;
        modeUnlockReward();
       
    }
    void modeUnlockReward()
    {
        PlayerPrefs.SetInt(Constant.modeNo + Constant.currentMode, 1);
        UnlockModeButton[Constant.currentMode].SetActive(false);
        checkModes();
    }
}

