using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DiscPieceBehavior : MonoBehaviour
{
    private GameObject parent;
    private bool dragState = false;
    private bool selectState = false; 

    //for rotation====
    private Vector3 originalDirection;
    public Mesh objMesh;
    public GameObject t_cubeObj;
    [Range(-180, 180)]
    public float t_rotationAngle = 0;
    private GameObject t_duplicatedSphere; 


    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;

        //initate changing color ===
        originalMateiral = GetComponent<MeshRenderer>().material; 

        


        //initate rotation ----
        objMesh = GetComponent<MeshFilter>().mesh;
        originalDirection = transform.TransformPoint(objMesh.vertices[48]) - parent.transform.position;

        //testing Script --
        Vector3 vertexPos = transform.TransformPoint(objMesh.vertices[48]);
        t_duplicatedSphere = Instantiate(t_cubeObj, vertexPos, Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {

        selectState = isSelected();
        

        checkDragState();
        changeColor(selectState, dragState);

        switch (selectState)
        {
            case true:
                if (!dragState)
                {
                    randomWalk();
                }
                else
                {
                    getDragged(); 
                }
               
                break;

            case false:
                randomWalk();
 
                break;
        }
    }
    void getDragged()
    {
        Debug.Log(offset);
    }

    void checkDragState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectState)
            {
                dragState = true; 
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragState = false; 
        }
    }

    public float walkSpeed = 0; 
    public void randomWalk()
    {
        transform.Translate(originalDirection * walkSpeed * Time.deltaTime, Space.World);
    }

    public Material originalMateiral, selectedMaterial, dragMaterial; 
    void changeColor(bool selected, bool dragged)
    {
        GetComponent<MeshRenderer>().material = selected? selectedMaterial : originalMateiral;
        if (dragged)
        {
            GetComponent<MeshRenderer>().material = dragMaterial; 
        }
    }

    Ray ray;
    RaycastHit hit;
    public int ignoredLayerMask;
    private Vector3 offset = Vector3.zero;
    bool isSelected()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit))
        {
            Vector3 impactPoint = hit.point;
            impactPoint.z = hit.collider.gameObject.transform.position.z;
            offset = hit.collider.gameObject.transform.position - impactPoint;

            if (GameObject.ReferenceEquals(hit.collider.gameObject, this.gameObject))
            {
                return true;
            }

        }
        return false;
    }

    //--Not used-----
    [Range(0, 1000)]
    public int vertexIndex = 0; 
    void debugVertex()
    {
        vertexIndex = Mathf.Clamp(vertexIndex, 0, objMesh.vertexCount-1);
        Vector3 refPoint = transform.TransformPoint(objMesh.vertices[vertexIndex]);
        t_duplicatedSphere.transform.position = refPoint;
    }
    void rotate2DAround() //The rotation angle is not figured out. 
    {
        Vector3 refPoint = transform.TransformPoint(objMesh.vertices[5]);
        t_cubeObj.transform.position = refPoint;
        Vector3 currentDirection = transform.position - parent.transform.position;

        float rotationAngle = -Vector3.SignedAngle(originalDirection, currentDirection, Vector3.forward);

        Debug.Log(rotationAngle);
        transform.localRotation = Quaternion.Euler(-90, 0, rotationAngle);


    }


    
}
