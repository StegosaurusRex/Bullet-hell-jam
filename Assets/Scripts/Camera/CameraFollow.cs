using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float xOffset;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = playerTransform.position.x + xOffset;
            transform.position = newPosition;
        }
        
    }
}
