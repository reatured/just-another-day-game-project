using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PO_TP_KnifeBehavior_L4_2 : PO_ToolProperty_L4_2
{
    public AnimationCurve chopCurveMovement;
    private float animationProgressInSecond = 0;
    public float animationDurationInSecond;
    public float chopLength;
    private Vector3 choppingOffset = Vector3.zero;
    public bool isChopping = false;
    public Transform choppingBoard;
    public float knifeOffsetAboveChoppingBoard; 
    public override void initiatePlane()
    {
        base.initiatePlane();
        toolMovementPlane = new Plane(Vector3.up, choppingBoard.position + new Vector3(0, knifeOffsetAboveChoppingBoard, 0));
    }

    public override void toolUpdate()
    {

        base.toolUpdate();
        transform.position += choppingOffset;
    }

    public override void clickBehavior()
    {
        base.clickBehavior();




        if (!isChopping)
        {
            isChopping = true;
            StartCoroutine(chop());
        }
        

    }

    IEnumerator chop()
    {
        choppingOffset = new Vector3(0, -chopLength, 0);

        yield return new WaitForSeconds(animationDurationInSecond);

        choppingOffset = Vector3.zero;
        isChopping = false;
    }
}
