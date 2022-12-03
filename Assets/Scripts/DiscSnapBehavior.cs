using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiscSnapBehavior : MonoBehaviour
{

    //for Snapping Behavior
    public PiecesTransform[] otherPieces;
    public PiecesTransform piecesTransform;
    public float snapDistance = 1f;

    public bool snappingState = false; 
    // Start is called before the first frame update
    void Start()
    {
        piecesTransform = GetComponent<PiecesTransform>();
        initiatePieceArray();

    }

    void initiatePieceArray()
    {
        otherPieces = transform.parent.GetComponentsInChildren<PiecesTransform>();
        for (int i = 0; i < otherPieces.Length; i++)
        {
            if (GameObject.ReferenceEquals(otherPieces[i].gameObject, this.gameObject))
            {
                otherPieces[i] = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (snappingState) onSnapping(); 
    }

    
    public void checkDistance()
    {
        piecesTransform.position = transform.position; 
        for(int i = 0; i < otherPieces.Length; i++)
        {
            
            if (otherPieces[i] != null && otherPieces[i].checkDistance)
            {
                float distance = (piecesTransform.position - otherPieces[i].position).magnitude;
                Debug.Log(distance);
                if (distance < snapDistance)
                {
                    onSnapEnter(); 
                    //otherPieces[i].attachedTo(this.transform);
                    piecesTransform.attachedTo(otherPieces[i].transform);
                }
            }
        }
    }
    public UnityEvent snapEnterEvent, snappingEvent;
    public void onSnapEnter()
    {
        snapEnterEvent.Invoke();
    }

    public void onSnapping()
    {
        snappingEvent.Invoke();
    }

    public void beSnapped()
    {
 
    }
}
