using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class VertexDragging : MonoBehaviour
{
    public bool dragState = false, selectState = false;
    public bool dragItself = true;
    public Transform draggedObj = null;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if (draggedObj == null) draggedObj = transform;
    }

    // Update is called once per frame
    void Update()
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        

        checkDragState();
        if (dragState)
        {
            onDragging();
        }

        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time);
        }

        mesh.vertices = vertices;
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
            if (GameObject.ReferenceEquals(hit.collider.gameObject, this.gameObject))
            {
                impactPoint = hit.point;
                Camera cam = Camera.main;
                Vector3 planeNormal = cam.transform.forward;
                planeNormal = planeNormal.normalized;

                //hit_plane = new Plane(Vector3.up, impactPoint);
                print(planeNormal);
                hit_plane = new Plane(planeNormal, impactPoint);
                offset = hit.collider.gameObject.transform.position - impactPoint;
                return true;
            }
        }
        return false;
    }

    void checkDragState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!dragState)
            {
                selectState = isSelected();
            }

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
            Vector3 newPosition = ray.GetPoint(enter) + offset;
            draggedObj.position = newPosition;

        }

        draggingEvent.Invoke();
    }

    public void onDragEnd()
    {
        dragState = false;
        dragEndEvent.Invoke();
    }
}
