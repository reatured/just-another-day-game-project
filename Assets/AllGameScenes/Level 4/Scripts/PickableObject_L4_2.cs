using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PickableObject_L4_2 : MonoBehaviour
{
    public bool isActive = false;
    public bool canUpdate = false; 
    public HandManager_L4 handManager;
    public Transform restTransform, pickUpTransform;
    private void Awake()
    {
        handManager = GameObject.Find("HandManager").GetComponent<HandManager_L4>();
    }

    public virtual void updateBehavior()
    {

    }

    //called by Tool Class mouseDown
    public void pickedUp()
    {
       
        handManager.clickEvent.AddListener(clickBehavior);
        handManager.ActiveObjectUpdateEvent.AddListener(updateBehavior);
        isActive = true;
    }

    //subscribe to hand manager script's clickEvent
    public virtual void clickBehavior()
    {

    }

    //called in Tool Class in click behavior
    public void putDown()
    {
        Debug.Log("Base put down");
        isActive = false;
        canUpdate = false; 
        handManager.clickEvent.RemoveListener(clickBehavior);
        handManager.ActiveObjectUpdateEvent.RemoveListener(updateBehavior);
        handManager.putDownObj(); 
    }
     

}
