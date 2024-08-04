using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public int SceneIndex;
    public Image fillbar;
    private bool is_fill = true;
    public float speed = 2.0f;
    public Text percantagetxt;
    public bool isSplash = false;

    private void Awake()
    {
        fillbar.fillAmount = 0.0f;
        //is_fill = false;
    }
    private void OnEnable()
    {
        if (isSplash)
        {
            is_fill = true;
            percantagetxt.text = "";

            fillbar.fillAmount = 0.0f;
            StartCoroutine(loadscene());
        }
        else
        {
            percantagetxt.text = "";

            fillbar.fillAmount = 0.0f;
            is_fill = false;
            Time.timeScale = 1.0f;
        }
       
    }
    
    void Update()
    {
        if (!is_fill)
            fillbarme();
    }
    void fillbarme()
    {

        fillbar.fillAmount = Mathf.Lerp(fillbar.fillAmount, 1.1f, Time.unscaledDeltaTime * speed);

        if(fillbar.fillAmount >= 0.9)
        {
            is_fill = true;
            fillbar.fillAmount = 1.0f;
            percantagetxt.text = 100.ToString() + "%";
            
            SceneManager.LoadScene(SceneIndex);

        }
        else
        {
            percantagetxt.text = ((int)(fillbar.fillAmount * 100)).ToString()+"%";
        }
    }

    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(speed);
        SceneManager.LoadScene(SceneIndex);
    }
}
