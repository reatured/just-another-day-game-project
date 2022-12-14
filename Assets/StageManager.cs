using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Range(1, 4)]
    public int stageIndex = 1; 
    public GameObject[] gameObjectsForTheStage;
    public Animator anim_Camera; 

    public bool transitionState = false;

    public GameObject nextStageManager; 

    private string cameraAnimationStageName; 
    // Start is called before the first frame update
    void Start()
    {
        anim_Camera = Camera.main.GetComponent<Animator>();
        cameraAnimationStageName = "Stage" + stageIndex; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionState) onStageEntering(); 
    }

    //--- Stage Enter
    public void onStageEnterStart()
    {
        anim_Camera.SetTrigger(cameraAnimationStageName);
    }

    public void onStageEntering()
    {

    }

    public void onStageEnterEnd()
    {
        for(int i = 0; i < gameObjectsForTheStage.Length; i++)
        {
            gameObjectsForTheStage[i].SetActive(true); 
        }
    }

    //--- Stage End
    public void onStageEndStart()
    {
        for (int i = 0; i < gameObjectsForTheStage.Length; i++)
        {
            gameObjectsForTheStage[i].SetActive(false);
        }
    }

    public void onStageEnding()
    {

    }

    public void onStageEndingEnd()
    {
    }


}
