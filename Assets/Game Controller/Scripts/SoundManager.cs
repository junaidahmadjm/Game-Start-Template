using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("---------------- [Audio Source] ----------------")]
    public AudioSource audioSource;
    [Header("------------------- [Audios] -------------------")]
    [Space(10)]
    public AudioClip BtnClick;


    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ButtonClickSound()
    {
        if(BtnClick && audioSource)
        {
            audioSource.PlayOneShot(BtnClick);

        }
    }
}
