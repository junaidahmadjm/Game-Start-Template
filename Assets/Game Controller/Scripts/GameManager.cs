using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("-------------------- [Game Manager] --------------------")]
    [Space(10)]
    public GameplayScript gameplay;
    public AutoTyping autoTyping;
    [HideInInspector]
    public LevelController levelController;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
}
