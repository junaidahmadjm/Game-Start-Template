using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoins : MonoBehaviour
{
    [Header("----------- [Coins Display Managemnet] -----------")]
    [Space(10)]

    public Text CoinsText;
    private void OnEnable()
    {
        ShowCoins();
    }
    public void ShowCoins()
    {
        if (CoinsText)
            CoinsText.text = PlayerPrefs.GetInt(Constant.coins).ToString();
    }
}
