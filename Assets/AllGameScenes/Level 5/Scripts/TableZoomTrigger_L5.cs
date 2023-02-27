using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableZoomTrigger_L5 : MonoBehaviour
{
    public MainCameraZoomInController_L5 cameraScript; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        cameraScript.startToZoom();
        print("Mouse Down");
    }
}
