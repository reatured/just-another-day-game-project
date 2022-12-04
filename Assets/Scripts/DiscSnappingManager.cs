using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiscSnappingManager : MonoBehaviour
{
    public PiecesTransform[] childPiecesTransform;
    public float snapDistance = 0.1f;
    
    public int totalPieces = 4;
    public int fixedPieces = 1; 

    // Start is called before the first frame update
    void Start()
    {
        childPiecesTransform = GetComponentsInChildren<PiecesTransform>();
        for(int i = 0; i < childPiecesTransform.Length; i++)
        {
            childPiecesTransform[i].index = i; 

        } 
    }
    public float distance = 0f; 

    public void checkDistance(int index)
    {

        PiecesTransform self = childPiecesTransform[index];
        for(int i = 0; i < childPiecesTransform.Length; i++)
        {
            if (i == index) continue; 

            PiecesTransform target = childPiecesTransform[i];
            if (target.needToCheckDistance() == false) continue; 

            distance = (self.position - target.position).magnitude;
            //Debug.Log("Distance to " + i + ": " +distance);
            if(distance < snapDistance)
            {
                Debug.Log("Snapping " + i + " to " + index);
                self.onSnapEnter();
                target.beSnappedTo(self.GetComponent<Transform>());

                fixedPieces++;
                if(fixedPieces == totalPieces)
                {

                }
                return;
            }
        }
    }
}
