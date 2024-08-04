using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class unlockchar : MonoBehaviour
{
    public int ColorID = 0;
    public int charID;
    public GameObject unlockpanel, lockedpanel;
    public Specifiation[] specifation;
    private void OnEnable()
    {
        Constant.selectedtexurecolor = ColorID;
        Constant.currentCharacter = charID;
        for (int i = 0; i < specifation.Length; i++)
        {
            StartCoroutine(fillbar(i));
        }
        if (PlayerPrefs.GetInt(Constant.unlockedCharacter+charID)==1)
        {
            Constant.currentCharacter = charID;
            unlockpanel.SetActive(true);
            lockedpanel.SetActive(false);
        }
        else
        {
            unlockpanel.SetActive(false);
            lockedpanel.SetActive(true);
        }
    }
   IEnumerator fillbar(int i)
   {
        
            specifation[i].fillbar.fillAmount = 0;
            DOTween.To(() => specifation[i].fillbar.fillAmount, xi => specifation[i].fillbar.fillAmount = xi, specifation[i].fillbarValue, 0.8f);

        yield return new WaitForSecondsRealtime(0.1f);
      

   }
}
[Serializable]
public class Specifiation
{
    public Image fillbar;
    public float fillbarValue;
}
