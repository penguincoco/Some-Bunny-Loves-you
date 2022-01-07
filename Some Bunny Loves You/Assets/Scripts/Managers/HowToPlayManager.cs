using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayManager : MonoBehaviour
{
    public GameObject tutorialObj;

    void OnEnable() 
    {
        if (CutsceneManager.Instance != null)
            CutsceneManager.Instance.PlayCutscene(tutorialObj);
    }

    void OnDisable() 
    {
        tutorialObj.gameObject.GetComponent<Cutscene>().StopAllCoroutines();
        tutorialObj.gameObject.GetComponent<Cutscene>().Reset();
        UIManager.Instance.StopAllCoroutines();
    }
}
