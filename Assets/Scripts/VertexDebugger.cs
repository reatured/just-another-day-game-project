using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDebugger : MonoBehaviour
{
    private Mesh objMesh;
    private GameObject debugSphere; 
    private Vector3 refPoint = Vector3.zero;

    public bool debugVertex = false; 
    public bool debugShader = false; 
    public Material debugMaterial = null;
    // Start is called before the first frame update
    void Start()
    {
        objMesh = GetComponent<MeshFilter>().mesh;
        debugSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        debugSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Destroy(debugSphere.GetComponent<Rigidbody>());
        Destroy(debugSphere.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (debugVertex)        debuggingVertex();
        if (debugShader)        debuggingShader();
        
    }



    [Range(0, 100)]
    public int vertexIndex = 0;
    void debuggingVertex()
    {
        vertexIndex = Mathf.Clamp(vertexIndex, 0, objMesh.vertexCount - 1);
        refPoint = transform.TransformPoint(objMesh.vertices[vertexIndex]);
        debugSphere.transform.position = refPoint;
        Debug.Log("debugging vertex");
    }

    void debuggingShader()
    {
        debugMaterial.SetFloat("_BendHeight", refPoint.y);
    }
}
