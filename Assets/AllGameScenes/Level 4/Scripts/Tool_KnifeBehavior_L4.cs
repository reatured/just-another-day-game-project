using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Tool_KnifeBehavior_L4 : ToolProperty_L4
{


    public void onPickedUp()
    {

    }

    public void onPutDown()
    {

    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    }


}
