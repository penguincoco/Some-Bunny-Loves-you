using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float stepSize;
    Vector3 camPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camPosition = Camera.main.gameObject.transform.position;
        camPosition.x += stepSize;
        Camera.main.gameObject.transform.position = camPosition;
    }
}
