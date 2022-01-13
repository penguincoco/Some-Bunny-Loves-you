using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    private static DebugManager _instance;
    public static DebugManager Instance { get { return _instance; } }

    public bool debugMode;
    public bool cameraDebugMode;

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start() 
    {
        if (debugMode) 
            GameManager.Instance.isPauseMenuOpen = false;
    }

    void Update() 
    {
        DebugKeys();
    }

    public void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
        
        //if (CameraManager.Instance != null)
        //{
        //    if (cameraDebugMode) 
        //        CameraManager.Instance.EnableMovements(false);
        //    else 
        //        CameraManager.Instance.EnableMovements(true);
        //}
    }
}
