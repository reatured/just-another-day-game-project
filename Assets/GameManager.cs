using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public enum StageNames
    {
        stage1,
        stage1NoPaper,
        stage2,
    };

    public StageNames stage;

    [Header("Stages and Objects ")]
    public GameObject[] stage1Objs;
    public GameObject[] stage2Objs;
    public GameObject paper;


    public GameObject[][] stageObjects; 

    [Range(1,4)] 
    public int startAtStage = 1;
    public GameObject[] stageManagers;

    private int currentStage;

    // Start is called before the first frame update

    private void Awake()
    {


        totalStage = stageManagers.Length;
        currentStage = startAtStage;
        goToStage(currentStage);


        //switch (stage)
        //{
        //    case StageNames.stage1:
        //        for (int i = 0; i < stage1Objs.Length; i++)
        //        {
        //            stage1Objs[i].SetActive(true);
        //        }
        //        for (int i = 0; i < stage2Objs.Length; i++)
        //        {
        //            stage2Objs[i].SetActive(false);
        //        }
        //        paper.SetActive(true);
        //        break;

        //    case StageNames.stage1NoPaper:
        //        for (int i = 0; i < stage1Objs.Length; i++)
        //        {
        //            stage1Objs[i].SetActive(true);
        //        }
        //        for (int i = 0; i < stage2Objs.Length; i++)
        //        {
        //            stage2Objs[i].SetActive(false);
        //        }
        //        paper.SetActive(false);

        //        break;
        //    case StageNames.stage2:

        //        for (int i = 0; i < stage1Objs.Length; i++)
        //        {
        //            stage1Objs[i].SetActive(false);
        //        }
        //        for (int i = 0; i < stage2Objs.Length; i++)
        //        {
        //            stage2Objs[i].SetActive(true);
        //        }
        //        break;


        //}

    }
    void Start()
    {


        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int totalStage = 4;
    public void nextStage()
    {
        currentStage++;
        if(currentStage <= totalStage)
        {
            goToStage(currentStage);
        }
        else
        {
            Debug.Log("No more stages");
        }
        
    }

    public void goToStage(int stageIndex)
    {
        if(stageManagers[stageIndex - 1])
        {
            stageManagers[stageIndex - 1].SetActive(false);
        }

        if (stageManagers[stageIndex])
        {
            stageManagers[stageIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Unavailable Stage Number");
        }
        
        
    }
}
