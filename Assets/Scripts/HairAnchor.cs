using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAnchor : MonoBehaviour
{
    public Vector2 partOffset = Vector2.zero;
    public float lerpSpeed = 20f;

    private Transform[] hairParts;
    private Transform hairAnchor;

    private void Awake() 
    {
        hairAnchor = GetComponent<Transform>();
        hairParts = GetComponentsInChildren<Transform>();
    }

    private void Update() 
    {
        Transform pieceToFollow = hairAnchor;

        foreach(Transform hairPart in hairParts)
        {
            // make sure we're not including the hair anchor, only the hair parts
            if (!hairPart.Equals(hairAnchor))
            {
                Vector2 targetPosition = (Vector2) pieceToFollow.position + partOffset;
                Vector2 newPositionLerped = Vector2.Lerp(hairPart.position, targetPosition, Time.deltaTime * lerpSpeed);
               
                hairPart.position = newPositionLerped;
                pieceToFollow = hairPart;
            }
        }
    }

}
