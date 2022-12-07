using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startFromStage1 = false, startFromStage2 = false;
    public GameObject[] stage1Objs, stage2Objs;
    public bool enablePaper = false;
    public GameObject paper; 
    // Start is called before the first frame update

    private void Awake()
    {
        if (startFromStage1)
        {
            for(int i = 0; i < stage1Objs.Length; i++)
            {
                stage1Objs[i].SetActive(true);
            }for(int i = 0; i < stage2Objs.Length; i++)
            {
                stage2Objs[i].SetActive(false);
            }
        }
        
        if (startFromStage2)
        {
            for(int i = 0; i < stage1Objs.Length; i++)
            {
                stage1Objs[i].SetActive(false);
            }for(int i = 0; i < stage2Objs.Length; i++)
            {
                stage2Objs[i].SetActive(true);
            }
        }

        if (enablePaper) paper.SetActive(true);
        else paper.SetActive(false);

    }
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
