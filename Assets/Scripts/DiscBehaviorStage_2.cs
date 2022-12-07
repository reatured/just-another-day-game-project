using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBehaviorStage_2 : MonoBehaviour
{
    public Animator animator_controller;
    public DraggingBehavior currentDB;

    public bool readyToPutIntoPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        animator_controller = GetComponentInChildren<Animator>();
        currentDB = GetComponent<DraggingBehavior>();

        currentDB.dragEnterEvent.AddListener(pickedUpY);
        currentDB.dragEndEvent.AddListener(putDownY);
    }

    public void pickedUpY()
    {
        animator_controller.SetBool("PickedUp", true);
    }

    public void putDownY()
    {
        if (!readyToPutIntoPlayer)
        {
            animator_controller.SetBool("PickedUp", false);
        }
        else
        {
            animator_controller.SetBool("OnPlayer", true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
