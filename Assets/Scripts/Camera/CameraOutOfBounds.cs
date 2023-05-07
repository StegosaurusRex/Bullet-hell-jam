using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOutOfBounds : MonoBehaviour
{
    public Camera mainCamera;
    public float buffer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float xMin = mainCamera.transform.position.x - cameraWidth / 2f + buffer;
        float xMax = mainCamera.transform.position.x + cameraWidth / 2f - buffer;
        float yMin = mainCamera.transform.position.y - mainCamera.orthographicSize + buffer;
        float yMax = mainCamera.transform.position.y + mainCamera.orthographicSize - buffer;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x , xMin , xMax) ,
                                         Mathf.Clamp(transform.position.y , yMin , yMax) ,
                                         transform.position.z);
    }

}
