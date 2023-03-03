using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DO_IVBag_L5 : DragObjectOnPlane_L5
{
    public Collider movementSurface; 
    public override Vector3 getImpactPoint()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (movementSurface.Raycast(ray, out hit, 100))
        {
            impactPoint = hit.point;
        }

        debuggingImpactPoint();
        return impactPoint; 
    }

    public override Vector3 getImpactNormal()
    {
        RaycastHit hit;
        Vector3 impactLookDirection = Vector3.zero;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (movementSurface.Raycast(ray, out hit, 100))
        {
            impactLookDirection = hit.normal;
        }

        return impactLookDirection;
    }

    public GameObject debugSphere;

    public void debuggingImpactPoint()
    {
        debugSphere.transform.position = impactPoint; 
    }
}
