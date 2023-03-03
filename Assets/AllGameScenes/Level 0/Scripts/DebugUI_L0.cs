using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugUI_L0 : MonoBehaviour
{
    public int currentSceneIndex = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel()
    {
        print("Go To Level " + SceneManager.sceneCount);
        if(currentSceneIndex < 5)
        {
            SceneManager.LoadScene(++currentSceneIndex);
        }
        
    }

    public void previousLevel()
    {
        print("Go To Level " + currentSceneIndex);
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(--currentSceneIndex);
        }
    }

    
}
