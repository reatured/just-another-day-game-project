using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolProperty_L4 : MonoBehaviour
{
    public bool isActive = false;
    public ToolManager_L4 toolManager;
    public Transform restTransform;
    public float putBackAreaSize;
    // Start is called before the first frame update
    void Start()
    {

        toolManager = GetComponentInParent<ToolManager_L4>();
        copyTransform(this.transform, restTransform);
        //this.enabled = false;
    }

    private Vector3 screenPoint;
    private Vector3 offset;
    private void OnMouseDown()
    {
        if (toolManager.toolInHand == null)
        {
            toolManager.pickUpObject(this.gameObject);
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        isActive = true;
    }



    private void OnMouseUp()
    {
        float distance = Vector3.Distance(this.transform.position, restTransform.position);
        if (distance < putBackAreaSize)
        {
            toolManager.putDownObject();
            
        }

        print(distance);
    }
    //=======================Helper Script
    void copyTransform(Transform from, Transform to)
    {
        to.position = from.position;
        to.rotation = from.rotation;
        to.localScale = from.localScale;
        print(to.position);
    }

}
