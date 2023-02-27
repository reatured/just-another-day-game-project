using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IVTubeManager_L5 : MonoBehaviour
{
    public IVTube_L5[] tubeSegments;
    // Start is called before the first frame update
    void Start()
    {
        foreach(IVTube_L5 seg in tubeSegments)
        {
            seg.initiateTube(); 
        }
    }


}
