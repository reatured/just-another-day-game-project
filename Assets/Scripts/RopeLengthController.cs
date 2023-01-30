using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeLengthController : MonoBehaviour
{

    ObiRopeCursor cursor;
    ObiRope rope;
    public float length; 
    // Start is called before the first frame update
    void Start()
    {
        rope = GetComponent<ObiRope>();
        cursor = GetComponent<ObiRopeCursor>();

        cursor.ChangeLength(length);
        print(rope.restLength);
    }

    // Update is called once per frame
    void Update()
    {

        length = rope.restLength;
    }
}
