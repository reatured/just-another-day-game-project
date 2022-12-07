using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class DiscSnappingManager : MonoBehaviour
{
    private PiecesTransform[] childPiecesTransform;
    public float snapDistance = 0.1f;
    
    private int totalPieces = 4;
    private int fixedPieces = 1;

    public GameObject stage2Record; 


    // Start is called before the first frame update
    void Start()
    {
        childPiecesTransform = GetComponentsInChildren<PiecesTransform>();
        for(int i = 0; i < childPiecesTransform.Length; i++)
        {
            PiecesTransform currentPT = childPiecesTransform[i];
            DraggingBehavior currentDB = currentPT.GetComponent<DraggingBehavior>();

            currentPT.index = i;
            currentDB.draggingEvent.AddListener(currentPT.checkSnappingDistance);
        }

        anim_controller = GetComponent<Animator>(); 
    }
    private float distance = 0f;

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
                    beginStage2();
                }
                return;
            }
        }
    }

    public void beginStage2()
    {
        stage2Record.SetActive(true);
        stage2Record.transform.position = transform.GetChild(0).position;
        Destroy(this.gameObject);
        Camera.main.GetComponent<Animator>().SetTrigger("Stage2");

    }

    public void removeAllChild()
    {
        GameObject recordWholePiece = new GameObject("recordWholePiece");
        recordWholePiece.transform.parent = this.transform; 
        //Instantiate(recordWholePiece, Vector3.zero, Quaternion.identity, this.transform);
        for(int i = childPiecesTransform.Length - 1; i >= 0; i--)
        {
            
            PiecesTransform currentPT = childPiecesTransform[i];
            DraggingBehavior currentDB = currentPT.GetComponent<DraggingBehavior>();

            
            
            currentDB.draggingEvent.RemoveAllListeners();
            currentDB.dragEnterEvent.AddListener(pickedUpY);
            currentDB.dragEndEvent.AddListener(putDownY);

            //toBe Removed
            

            currentDB.draggedObj = recordWholePiece.transform;
            currentDB.transform.parent = recordWholePiece.transform;
            currentDB.transform.localPosition = new Vector3(0, 0, 0);

            //Till here removed; 
            //childPiecesTransform[i].GetComponent<DraggingBehavior>().draggingEvent.
            Destroy(childPiecesTransform[i]);
        }
    }

    private Animator anim_controller; 
    public void pickedUpY()
    {
        anim_controller.SetBool("PickedUp", true);
    }

    public void putDownY()
    {
        if (!readyToPutIntoPlayer)
        {
            anim_controller.SetBool("PickedUp", false);
        }
        else
        {
            anim_controller.SetBool("OnPlayer", true);
        }
        
    }

    public bool readyToPutIntoPlayer = false; 
}
