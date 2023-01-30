using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPieceBehavior : MonoBehaviour
{

    public int index;
    public Vector3 uiPosition; 
    private void Start()
    {
        transform.position = uiPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void initiate(int i, Vector3 v)
    {
        index = i;
        uiPosition = v;
    }
}
