using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickingUpRecipe_L4 : MonoBehaviour
{
    public Transform trans_pickedUp, trans_rest;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    

    private void OnMouseDown()
    {
        pickUp();
    }

    private void OnMouseUp()
    {
        pickDown();
    }

    void pickUp()
    {
        copyTransform(trans_pickedUp, transform);
    }
    void pickDown()
    {
        copyTransform(trans_rest, transform);
    }

    void copyTransform(Transform from, Transform to)
    {
        to.position = from.position;
        to.rotation = from.rotation;
        to.localScale = from.localScale;
    }

}
