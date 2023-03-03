using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackBehavior_L5 : MonoBehaviour
{
    public GameObject backPack;
    bool bagOpened = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openBag()
    {
        backPack.SetActive(true);
        bagOpened = true;
    }

    public void closeBag()
    {
        backPack.SetActive(false);
        bagOpened = false;
    }

    public void toggleBag()
    {
        if (bagOpened)
        {
            closeBag();

        }
        else if (!bagOpened)
        {
            openBag();
        }

    }

    public void toggleBag(bool toOpen)
    {
        if (toOpen)
        {
            openBag();
        }else if (!toOpen)
        {
            closeBag();
        }
    }


}
