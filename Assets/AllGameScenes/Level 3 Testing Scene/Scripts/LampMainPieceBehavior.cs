using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMainPieceBehavior : MonoBehaviour
{
    public Transform uiPieceTransform;
    public GameObject[] pieces;
    public LampPieceBehavior[] lampPieces;

    private void Awake()
    {
        lampPieces = transform.GetComponentsInChildren<LampPieceBehavior>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lampPieces.Length; i++)
        {
            LampPieceBehavior piece = lampPieces[i];
            piece.index = i;
            piece.uiPosition = uiPieceTransform.position;
        }
    }
}
