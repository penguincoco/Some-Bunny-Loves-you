using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Component[] parallaxScrs;
    public CameraMovement camMovementScr;

    private static CameraManager _instance;
    public static CameraManager Instance { get { return _instance; } }    

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

    public void Start() 
    {
        parallaxScrs = this.gameObject.GetComponents(typeof(Parallax));
        camMovementScr = this.gameObject.GetComponent<CameraMovement>();
    }

    void Update() 
    {
        if (GameManager.Instance.debugMode) 
        {
            EnableMovements(false);
        }
    }

    public void EnableMovements(bool enable) 
    {
        foreach(Parallax parallaxScr in parallaxScrs) 
            parallaxScr.enabled = enable;
        
        camMovementScr.enabled = enable;
    }
}
