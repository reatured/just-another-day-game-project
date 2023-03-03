using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events; 
public class MainCameraZoomInController_L5 : MonoBehaviour
{
    void Start()
    {
        if(originalTransform == null)
        {
            originalTransform = new GameObject().transform;
            copyTransform(Camera.main.transform, originalTransform);
        }
    }
    void Update()
    {
        zoomToTableController();
    }


    //====zooming

    public Transform targetTransform;
    public Transform originalTransform;
    public float animationDurationInSecond = 1f;
    public AnimationCurve animationCurve;

    float startTime = 0.0f; 
    bool zoomingAction = false;
    bool zoomState = false; //false is not zoomed In, look down

    public void startToZoom()
    {
        if(!zoomingAction) startTime = Time.time;

        zoomingAction = true;
       
    }
    void zoomToTableController()
    {
        if (zoomingAction)
        {

            zooming();
        }
    }

    void startZoomIn()
    {
        zoomingAction = true;
    }

    void zooming()
    {
        bool isArrived = false;
        if (!zoomState)
        {
            isArrived = zoomIn();
        }
        else
        {
            isArrived = zoomOut();
        }

        if (isArrived)
        {
            finishingZooming(); 
        }

    }

    bool zoomIn()
    {

        float journeyTime = (Time.time - startTime) / animationDurationInSecond;
        float progress = animationCurve.Evaluate(journeyTime);
        lerpTransform(originalTransform, targetTransform, progress);


        if(journeyTime > 1)
        {
            return true;
        }
        return false; 
        
    }

    bool zoomOut()
    {
        float journeyTime = (Time.time - startTime) / animationDurationInSecond;
        float progress = animationCurve.Evaluate(journeyTime);
        lerpTransform(targetTransform, originalTransform, progress);


        if (journeyTime > 1)
        {
            return true;
        }
        return false;
    }

    public UnityEvent<bool> endZoomingEvent; 
    void finishingZooming()
    {
        zoomingAction = false;
        endZoomingEvent.Invoke(zoomState); 
        zoomState = !zoomState;
        
    }

    //==Helper Srcript

    void lerpTransform(Transform originalTrans, Transform targetTrans, float progress)
    {
        Camera.main.transform.position = Vector3.Lerp(originalTrans.position, targetTrans.position, progress);
        Camera.main.transform.rotation = Quaternion.Lerp(originalTrans.rotation, targetTrans.rotation, progress);
    }
    void copyTransform(Transform from, Transform to)
    {
        to.position = from.position;
        to.rotation = from.rotation;
        to.localScale = from.localScale;
    }
}
