using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBaseBehavior : MonoBehaviour
{
    private Vector3 screenPoint;
    public float startingX;
    public float lastX;
    public float draggingX;
    public float deltaX; 
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
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        startingX = Input.mousePosition.x;

        print("mouse down");
    }

    private void OnMouseDrag()
    {
        draggingX = Input.mousePosition.x ;
        deltaX =  startingX - draggingX + lastX;

        transform.rotation = Quaternion.Euler(0, deltaX, 0);
    }

    private void OnMouseUp()
    {
        lastX = deltaX; 
    }
}
