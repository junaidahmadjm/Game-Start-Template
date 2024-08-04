using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsentScript : MonoBehaviour
{
    public GameObject ConsentScreen, LoadingPanel;
    private void OnEnable()
    {
        StartCoroutine(WaitForInitialization());
        if (PlayerPrefs.GetInt("ConsentAccept") == 0)
        {
            PlayerPrefs.SetInt("ConsentAccept", 1);
            if (ConsentScreen)
            {
                ConsentScreen.SetActive(true);
            }
            if (LoadingPanel)
            {
                LoadingPanel.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("ConsentAccept", 1);
            if (ConsentScreen)
            {
                ConsentScreen.SetActive(false);
            }
            if (LoadingPanel)
            {
                LoadingPanel.SetActive(true);
            }
        }
    }
    IEnumerator WaitForInitialization()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        //CSUtility.Instance?.initCSUtility(true, GoogleMobileAds.Api.AdSize.Banner, GoogleMobileAds.Api.AdPosition.Top);
    }
    public void AcceptButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        OnEnable();
    }
    public void DeclineButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        OnEnable();
    }
    public void PrivacyPolicyButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        Application.OpenURL("");
    }
}
