using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainCameraMovement_L5 : MonoBehaviour
{
    Transform camTrans;
    bool isLookingDown = true;
    public MainCameraZoomInController_L5 camController; 
    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        if(mousePosition.y >= 1080)
        {
            if (isLookingDown)
            {
                camController.startToZoom();
            }
        }else if(mousePosition.y <= 0)
        {
            if (!isLookingDown)
            {
                camController.startToZoom();
            }
        }
    }

    public void switchState()
    {
        isLookingDown = !isLookingDown; 
    }
}
