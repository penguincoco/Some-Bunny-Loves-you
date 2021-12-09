using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float stepSize;

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject obj in GameManager.Instance.backgroundObjs)
        {
            Vector3 objPos = obj.transform.position;
            objPos.x += stepSize;
            obj.transform.position = objPos;
        }
    }
}
