using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Stage[] stages;
    public int totalStage;
    public int currentStage = 0;

    [Range(1, 4)]
    public int startFromStage = 1;

    
    
    // Start is called before the first frame update
    void Start()
    {
        totalStage = stages.Length;
        currentStage = startFromStage;
        goToStage(currentStage);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextStage()
    {
        currentStage++;

        goToStage(currentStage);
    }

    public void goToStage(int stageIndex)
    {
        stageIndex--; 

        print("Go To: " + stageIndex);
        if (stageIndex - 1 >= 0)   
        {
            stages[stageIndex - 1].endStage();
        }
        if (stageIndex < stages.Length)
        {
            stages[stageIndex].startStage();
        }
        else
        {
            print("Stage Not Existing");
        }

    }

    
}


