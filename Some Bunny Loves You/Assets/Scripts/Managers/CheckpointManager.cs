using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public bool gameOver = false;
    public Vector2 startPoint;
    public Vector2 endPoint;

    public GameObject endingCutsceneObj;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.gameObject.transform.position.x >= endPoint.x && !gameOver)
        {
            CameraManager.Instance.EnableMovements(false);
            endingCutsceneObj.gameObject.GetComponent<Cutscene>().CutsceneWrapper();
            gameOver = true;
        }
    }
}
