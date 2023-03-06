using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PO_TP_WaterBottle_L4_2 : PO_ToolProperty_L4_2
{
    public override void initiatePlane()
    {
        base.initiatePlane();
        Vector3 planeNormal = transform.position - Camera.main.transform.position;
        toolMovementPlane = new Plane(planeNormal, transform.position); 
    }
    public override void toolUpdate()
    {
        base.toolUpdate();

    }

    public override void clickBehavior()
    {
        base.clickBehavior();
        //float distance = Vector3.Distance(this.transform.position, restTransform.position);
        //if (distance < 1)
        //{
        //    putDown();
        //}

    }
}
