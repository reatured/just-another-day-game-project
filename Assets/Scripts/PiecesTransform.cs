using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesTransform : MonoBehaviour
{
    public Vector3 position;
    private Transform objTrans;
    public Transform rootTrans;
    public bool checkDistance = true;
    public int index;

    private DiscSnappingManager snappingManager;
    // Start is called before the first frame update
    void Start()
    {
        snappingManager = transform.parent.GetComponent<DiscSnappingManager>();
        position = transform.position;
        objTrans = transform;
        rootTrans = objTrans;
    }


    public void beingDragged()
    {
        checkDistance = false;
    }

    public GameObject getParentObj()
    {
        return this.rootTrans.gameObject;
    }

    public void attachedTo(Transform parentTrans)
    {
        transform.parent = parentTrans;
        //transform.localPosition = Vector3.zero;

        PiecesTransform[] childs = GetComponentsInChildren<PiecesTransform>();
        DraggingBehavior[] dgBehavior = GetComponentsInChildren<DraggingBehavior>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].rootTrans = parentTrans;
            childs[i].GetComponent<DraggingBehavior>().draggedObj = parentTrans; 
        }



        checkDistance = false;
        //GetComponent<PiecesAttachingBehavior>().setParentRotation(GetComponentInParent<ManageDiscPieces>().getRotation());
        //GetComponent<PiecesAttachingBehavior>().enabled = true;

    }

    public void moveTowardParent()
    {
        position = rootTrans.position;

        transform.position = position; 
    }

    public void moveRoot(Vector3 rootPos)
    {
        rootTrans.position = rootPos;
    }

    public void checkSnappingDistance() {
        rootTrans.GetComponent<PiecesTransform>().position = rootTrans.position;
        snappingManager.checkDistance(rootTrans.GetComponent<PiecesTransform>().index);
    }

    //*Done Stop Dragging
    public void onSnapEnter()
    {
        GetComponent<DraggingBehavior>().onDragEnd();
    }

    //*Done Change the root 
    //*Done Change the bool: checkDistance 
    // Change the draggedObj in draggingBehaivor; 
    //Move Toward the Root
    public void beSnappedTo(Transform parentTrans)
    {
        checkDistance=false;
        attachedTo(parentTrans);
        moveTowardParent();
    }

}
