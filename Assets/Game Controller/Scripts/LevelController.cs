using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    
    [Header("---------------- [If you want Custom Vehicle for this level] ----------------")]
    [Space(10)]
    [Header("---------------- [Level Controller] ----------------")]
    [Space(10)]
    public bool isCustomVehicle;
    public int vehicleNo;

    [Header("---------------- [Player Starting Position] ----------------")]
    [Space(10)]
    public Transform startPosition;

    [Header("---------------- [Cutscene Settings] ----------------")]
    [Space(10)]
    public bool isCutsceneOnStart;
    public GameObject[] cutScenes;

    public string[] ObjectiveText;
    private void Awake()
    {
        DisableCutScenes();
        if(isCustomVehicle)
        {
            Constant.currentCharacter = vehicleNo;
        }
    }
    private void Start()
    {
        if (GameManager.instance)
        {
            GameManager.instance.levelController = this;
            if (ObjectiveText.Length != 0)
                GameManager.instance.autoTyping.SetObjectiveText(ObjectiveText[0]);
        }
    }
    public void PlayCutScene(int index)
    {
        DisableCutScenes();
        cutScenes[index].SetActive(true);
    }
    void DisableCutScenes()
    {
        foreach (var item in cutScenes)
        {
            if (item)
                item.SetActive(false);

        }
    }
}
