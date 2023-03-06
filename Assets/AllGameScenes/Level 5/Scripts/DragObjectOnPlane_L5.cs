using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObjectOnPlane_L5 : MonoBehaviour
{
    Vector3 offset;
    Plane movementPlane;
    public Vector3 planeNormal;
    protected Ray ray;

    public Transform receiver;
    public float receiverSize = 1f;

    public bool isActive = false;

    
    private void OnMouseDown()
    {
        print("Mouse Down");
        movementPlane = new Plane(planeNormal, transform.position);

        ray = getRay(Camera.main.transform, transform);
        offset =  transform.position - getImpactPoint();
        isActive = true;
    }

    private void OnMouseDrag()
    {
        if (!isActive) return;
        transform.position = getImpactPoint() /*+ offset*/;
        transform.forward = getImpactNormal(); 
        //float distance = Vector3.Distance(receiver.position, transform.position);
        //if(distance < receiverSize)
        //{
        //    transform.position = receiver.position;
        //    transform.parent = receiver;
        //    GetComponent<Collider>().enabled = false;
        //    this.enabled = false;
        //    isActive = false;
        //}
    }
    public virtual Vector3 getImpactNormal()
    {

        return transform.forward; 
    }

    private void OnMouseUp()
    {
        isActive = false; 
    }

    //---Helper Scripts
    public Ray getRay(Transform obj1, Transform obj2)
    {
        return new Ray(obj1.position, obj2.position - obj1.position);
    }

    public Vector3 impactPoint;
    public virtual Vector3 getImpactPoint()
    {
        print(impactPoint);
        float enter = 0f;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (movementPlane.Raycast(ray, out enter))
        {
            impactPoint = ray.GetPoint(enter);

        }

        return impactPoint;
    }
}
