using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.gameObject.transform.position.x >= endPoint.x) 
            CameraManager.Instance.EnableMovements(false);
    }
}
