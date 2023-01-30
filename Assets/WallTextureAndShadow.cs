using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTextureAndShadow : MonoBehaviour
{

    public Material mat_Wall;
    public GameObject lightBulb; 
    // Start is called before the first frame update
    void Start()
    {
        mat_Wall = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(lightBulb.transform.position, this.transform.position);
        mat_Wall.SetFloat("_Distance", distance);
    }
}
