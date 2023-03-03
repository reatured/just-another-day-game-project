using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class IVSpeedController_L5 : MonoBehaviour
{
    public GameObject[] tubeSegs;
    public Material[] tubeMats;

    [Range(0,1)]
    public float tubePercentile = 0; 

    // Start is called before the first frame update
    void Start()
    {
        tubeMats = new Material[tubeSegs.Length];
        for (int i = 0; i < tubeSegs.Length; i++)
        {
            tubeMats[i] = tubeSegs[i].GetComponent<MeshRenderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tubeSegs.Length; i++)
        {
            tubeMats[i].SetFloat("_Dripping_Percentile", tubePercentile);
        }
        tubePercentile += speed * Time.deltaTime; 
    }

    public float speed = 0f; 
    private void OnMouseDown()
    {
        print("MouseDown");
        speed = 0.1f;

    }

    private void OnMouseDrag()
    {
        print("dragged");
    }

}
