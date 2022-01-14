using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public bool debugMode;
    private static CutsceneManager _instance;
    public static CutsceneManager Instance { get { return _instance; } }

    public float globalFadeWaitTime;
    public Image blackImg;
    public FadeObject fadeScr;

    public GameObject introObj;
    public GameObject endingObj;

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
        fadeScr = this.gameObject.GetComponent<FadeObject>();
        if (introObj != null && !DebugManager.Instance.debugMode)
            PlayCutscene(introObj);

        if (DebugManager.Instance.debugMode)
            introObj.SetActive(false);
    }

    public void PlayCutscene(GameObject cutsceneObj) 
    {
        if (cutsceneObj.gameObject.GetComponent<Cutscene>() != null)
            cutsceneObj.gameObject.GetComponent<Cutscene>().CutsceneWrapper();
    }
}
