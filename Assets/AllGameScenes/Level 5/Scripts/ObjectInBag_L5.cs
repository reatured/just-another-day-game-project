using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInBag_L5 : MonoBehaviour
{
    public GameObject objOnTable;
    public BackPackBehavior_L5 bagController;
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
        objOnTable.SetActive(true);
        bagController.toggleBag(false); 
        this.gameObject.SetActive(false);
    }
}
