using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoTyping : MonoBehaviour
{
    [HideInInspector]
    public string TypingText;
    public Text[] ContainText;
    public float TypingDelay;
    public GameObject InGameMessagePanel;
    public GameObject[] ok;
    private int index;
    
    private void OnEnable()
    {
        if (InGameMessagePanel)
            InGameMessagePanel.SetActive(false);
        foreach (var item in ContainText)
        {
            if (item)
                item.text = "";
        }
        foreach (var item in ok)
        {
            if (item)
                item.SetActive(false);
        }
    }
    IEnumerator typetxt()
    {
        if(index>=0 && index<=1)
        ContainText[index].text = TypingText;
        yield return new WaitForSecondsRealtime(0.0f);
        if (index >= 0 && index <= 1)
            ok[index].SetActive(true);
    }
    public void SetObjectiveText(string objectivetxt)
    {
        index = 0;
        if (index >= 0 && index <= 1)
            ContainText[index].text = "";

        TypingText = objectivetxt;
        StartCoroutine(typetxt());
    }
    public void SetObjectiveText(string objectivetxt,int index)
    {
        this.index = index;
        InGameMessagePanel.SetActive(true);
        if (index >= 0 && index <= 1)
            ContainText[index].text = "";

        TypingText = objectivetxt;
        StartCoroutine(typetxt());
    }
    public void IngameMessageOkPressed()
    {
        SoundManager.instance?.ButtonClickSound();
        if (InGameMessagePanel)
        InGameMessagePanel.SetActive(false);
    }
}
