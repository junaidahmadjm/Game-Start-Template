using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [Header("----------- [Level Selection (Locking / Unlocking)] -----------")]
    [Header("----------------[Select the option]----------------")]
    [Space(10)]
    public bool UnlockAllLevels_Check;
    public bool SimpleLevelUnlock;
    public bool UnlockLevelUsingWatchAd;

    [Header("----------- [Level Buttons and Locks] -----------")]
    [Space(10)]
    public GameObject[] LevelButtons;
    public GameObject[] Locks;
    public GameObject[] UnlockLevelButton;

    private void OnEnable()
    {
        unlockFirstLevel();
        unlockAllLevel();
        unlockLevel();
    }

    /*-----------------------------------If Unlock All Levels check is true-------------------------------------*/
    private void unlockAllLevel()
    {
        if(UnlockAllLevels_Check)
        {
            foreach (var item in Locks)
            {
                item.SetActive(false);
            }
            foreach (var item in LevelButtons)
            {
                item.SetActive(true);
            }
        }
        
    }

    /*-----------------------------------If Simple Unlock Level / Watch Ad check is true-------------------------------------*/
    private void unlockLevel()
    {
        if (SimpleLevelUnlock || UnlockLevelUsingWatchAd)
        {
            for (int i = 1; i <= Constant.totalLevels; i++)
            {
                if (PlayerPrefs.GetInt(Constant.unlockedLevel + Constant.currentMode + i) == 1)
                {
                    LevelButtons[i].SetActive(true);
                    Locks[i].SetActive(false);
                    UnlockLevelButton[i].SetActive(false);
                }
                else
                {
                    LevelButtons[i].SetActive(false);
                    Locks[i].SetActive(true);
                    UnlockLevelButton[i].SetActive(true);
                }
            }
        }
    }

    void unlockFirstLevel()
    {
        if(PlayerPrefs.GetInt(Constant.unlockedLevel + Constant.currentMode + 1)==0)
        {
            PlayerPrefs.SetInt(Constant.unlockedLevel + Constant.currentMode + 1, 1);
        }
    }
    /*-----------------------------------Unlock Level by Watching Ad-------------------------------------*/
    public void unlockLevelByWatchAd(int Level)
    {
        SoundManager.instance?.ButtonClickSound();
        Constant.currentLevel = Level;
        levelUnlockReward();
    }
    void levelUnlockReward()
    {
        PlayerPrefs.SetInt(Constant.unlockedLevel + Constant.currentMode + Constant.currentLevel, 1);
        UnlockLevelButton[Constant.currentLevel].SetActive(false);
        unlockLevel();
    }
   
    

}
