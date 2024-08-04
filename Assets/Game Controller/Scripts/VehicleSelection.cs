using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class VehicleSelection : MonoBehaviour
{
    [Header("---------------- [Vehicles / Players] ----------------")]
    [Space(10)]
    public Rigidbody[] Vehicles;
    [Header("--------------- [Vehicles Properties] ---------------")]
    [Space(10)]
    public GameObject[] PropertiesPanel;
    [Header("--------------- [Vehicles Prices] ---------------")]
    [Space(10)]
    public int[] Prices;
    public Text PriceText;
    int CurrentVehicle;
    [Header("--------------- [Screens] ---------------")]
    [Space(10)]
    public GameObject NotEnoughCoinsScreen;
    public GameObject LoadingScreen;
    public float HighValueForEffect = 0.1f;
    [Header("--------------- [Vehicle Camera Positions] ---------------")]
    [Space(10)]
    public Transform[] VehicleCameraPosition;
    public float CameraSpeed = 2.0f;
    public Transform CameraPosition;

    private void OnEnable()
    {
        foreach (var item in Vehicles)
        {
            if (item)
                item.gameObject.SetActive(true);
        }
        CurrentVehicle = 1;
        TurnOn_OffVehicle(CurrentVehicle);
        foreach (var item in Vehicles)
        {
            if (item)
                item.isKinematic = true;
        }
    }

    public void OnNextPressed()
    {
        SoundManager.instance?.ButtonClickSound();
        CurrentVehicle++;
        if(CurrentVehicle>=Vehicles.Length)
        {
            CurrentVehicle = 1;
        }
        TurnOn_OffVehicle(CurrentVehicle);
    }
    public void OnPreviousPressed()
    {
        SoundManager.instance?.ButtonClickSound();
        CurrentVehicle--;
        if (CurrentVehicle < 1)
        {
            CurrentVehicle = Vehicles.Length - 1;
        }
        TurnOn_OffVehicle(CurrentVehicle);
    }
    void TurnOn_OffVehicle(int VehicleNo)
    {
        foreach (var item in Vehicles)
        {
            if (item)
                item.isKinematic = true;
        }
        foreach (var item in PropertiesPanel)
        {
            if (item)
                item.SetActive(false);
        }
        ChangeVehiclePosition(CurrentVehicle);
        Vector3 temp = new Vector3(0, HighValueForEffect, 0);
        Vehicles[VehicleNo].transform.position = Vehicles[VehicleNo].transform.position + temp;
        Vehicles[VehicleNo].isKinematic = true;
        Vehicles[VehicleNo].gameObject.SetActive(true);
        PropertiesPanel[VehicleNo].SetActive(true);
        PriceText.text = Prices[VehicleNo].ToString();
        
    }
    public void ChangeVehiclePosition(int Num)
    {
        CameraPosition.DOLocalMove(VehicleCameraPosition[Num].transform.localPosition, CameraSpeed);
        CameraPosition.DOLocalRotate(VehicleCameraPosition[Num].transform.eulerAngles, CameraSpeed);
    }
    public void BuyButtonClicked()
    {
        SoundManager.instance?.ButtonClickSound();
        int temp = PlayerPrefs.GetInt(Constant.coins);
        if(temp >= Prices[CurrentVehicle])
        {
            temp = temp - Prices[CurrentVehicle];
            PlayerPrefs.SetInt(Constant.coins, temp);
            PlayerPrefs.SetInt(Constant.unlockedCharacter + CurrentVehicle, 1);
            DisplayCoins CoinsShow = FindObjectOfType<DisplayCoins>();
            CoinsShow.ShowCoins();
            TurnOn_OffVehicle(CurrentVehicle);
        }
        else
        {
            NotEnoughCoinsScreen.SetActive(true);

        }
    }
    public void WatchAdsToGetCoins()
    {
        SoundManager.instance?.ButtonClickSound();

        onCoinsRewardComplete();
    }
    void onCoinsRewardComplete()
    {
        int temp = PlayerPrefs.GetInt(Constant.coins);
        temp = temp + 200;
        PlayerPrefs.SetInt(Constant.coins, temp);
        DisplayCoins CoinsVal = FindObjectOfType<DisplayCoins>();
        CoinsVal.ShowCoins();

    }
    public void SelectButtonClicked()
    {
        LoadingScreen.SetActive(true);
        Debug.Log("Mode No. " + Constant.currentMode);
        Debug.Log("Level No. " + Constant.currentLevel);
        Debug.Log("Vehicle No. " + Constant.currentCharacter);
    }
    public void ButtonClickSound()
    {
        SoundManager.instance?.ButtonClickSound();
    }
    private void OnDisable()
    {
        foreach (var item in Vehicles)
        {
            if (item)
                item.gameObject.SetActive(false);
        }
        foreach (var item in PropertiesPanel)
        {
            if (item)
                item.SetActive(false);
        }
    }
}
