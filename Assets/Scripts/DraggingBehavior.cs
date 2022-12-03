using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggingBehavior : MonoBehaviour
{
    
    public bool dragState = false, selectState = false;
    public bool dragItself = true;
    public Transform draggedObj = null;

    public int index; 
    private PiecesTransform thisPieceTransform; 

    // Start is called before the first frame update
    void Start()
    {

        if(draggedObj == null) draggedObj = transform;
        thisPieceTransform = GetComponent<PiecesTransform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragState)
        {
            selectState = isSelected();
        }

        checkDragState();
        if (dragState)
        {
            onDragging(); 
        }

    }

    Ray ray;
    RaycastHit hit;
    private Vector3 offset = Vector3.zero;
    public Plane hit_plane;
    public Vector3 impactPoint; 
    bool isSelected()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            impactPoint = hit.point;
            //impactPoint.z = hit.collider.gameObject.transform.position.z;

            hit_plane = new Plane(Vector3.up, impactPoint);
            offset = hit.collider.gameObject.transform.position - impactPoint;

            if (GameObject.ReferenceEquals(hit.collider.gameObject, this.gameObject))
            {
                return true;
            }

        }
        return false;
    }

    void checkDragState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectState)
            {
                if (!dragState)
                {
                    dragState = true;
                    onDragEnter();
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (dragState)
            {
                
                onDragEnd();
            }
        }
    }

    public UnityEvent dragEnterEvent, dragEndEvent, draggingEvent;

    void onDragEnter()
    {
        dragEnterEvent.Invoke(); 
    }

    void onDragging()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (hit_plane.Raycast(ray, out enter))
        {
            draggedObj.position = ray.GetPoint(enter) + offset;
        }

        draggingEvent.Invoke(); 
    }

    public void onDragEnd()
    {
        dragState = false;
        dragEndEvent.Invoke();

    }
}
