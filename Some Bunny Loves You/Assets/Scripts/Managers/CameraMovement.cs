using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool camMoving;
    public float stepSize;
    Vector3 camPosition;

    private static CameraMovement _instance;
    public static CameraMovement Instance { get { return _instance; } }    

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (camMoving) 
        {
            camPosition = Camera.main.gameObject.transform.position;
            camPosition.x += stepSize;
            Camera.main.gameObject.transform.position = camPosition;
        }
    }

    public void SetCamMoving(bool camMoving) {
        this.camMoving = camMoving;
    }
}
