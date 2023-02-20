using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PO_ToolProperty_L4_2 : PickableObject_L4_2
{
    protected Vector3 screenPoint;
    protected Vector3 offset;
    public float putBackAreaSize = 0.35f;
    public Plane toolMovementPlane;


    //1. onMouseDown(Pick Up)!: 
    // Base Class -> pickedUp(); 
    // Tool Class -> pickUpObject(); 
    private void OnMouseDown()
    {
        Debug.Log("```````Mouse Down");
        if (isActive == false)
        {
            pickedUp(); //in Base Class
            pickUpObject(); //in Tool Class

        }
    }


    public void pickUpObject()
    {
        copyTransform(this.transform, restTransform);
        copyTransform(pickUpTransform, this.transform);
        if (handManager.objectInHand == null)
        {
            handManager.pickUpObject(this.gameObject);
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));



        Cursor.visible = false;
    }

    public virtual void initiatePlane()
    {

    }

    //2. Update 
    //Hand Manager -> pickable script (base) -> here -> knife class
    public override void updateBehavior()
    {
        base.updateBehavior();
        
        //Debug.Log("Tool Class");
        toolUpdate();
    }
    //Here -> knife class
    public virtual void toolUpdate()
    {
        followMouse();
    }
    
    public void followMouse()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        newPosition.y = 0.2f;
        transform.position = newPosition;

    }

    //3. Mouse Clicked:: Click Behavior::

    public override void clickBehavior()
    {
        base.clickBehavior();
       
        if (checkIfPutBack())
        {
            return;
        }
    }
    public bool checkIfPutBack()
    {
        float distance = Vector3.Distance(transform.position, restTransform.position);
        print("distance: " + distance);
        if (distance < putBackAreaSize)
        {
            copyTransform(restTransform, transform);

            
            Cursor.visible = true;
            putDown();

            Debug.Log("Too Short");

            return true;

        }

        return false;
    }

    //__________________Helper Functions
    void copyTransform(Transform from, Transform to)
    {
        to.position = from.position;
        to.rotation = from.rotation;
        to.localScale = from.localScale;
        print(to.position);
    }
}
