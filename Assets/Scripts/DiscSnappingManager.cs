using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSnappingManager : MonoBehaviour
{
    public PiecesTransform[] childPiecesTransform;
    public float snapDistance = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        childPiecesTransform = GetComponentsInChildren<PiecesTransform>();
        for(int i = 0; i < childPiecesTransform.Length; i++)
        {
            childPiecesTransform[i].index = i; 

        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float distance = 0f; 
    public void checkDistance(int index)
    {
        PiecesTransform self = childPiecesTransform[index];
        for(int i = 0; i < childPiecesTransform.Length; i++)
        {
            if (i == index) continue; 

            PiecesTransform target = childPiecesTransform[i];
            if (target.checkDistance == false) continue; 

            distance = (self.position - target.position).magnitude;
            if(distance < snapDistance)
            {
                Debug.Log("Snapping " + i + " to " + index);
                self.onSnapEnter();
                target.beSnappedTo(self.GetComponent<Transform>());

                return;
            }
        }
    }
}
