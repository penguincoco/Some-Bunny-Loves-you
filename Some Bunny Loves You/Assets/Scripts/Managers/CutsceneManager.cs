using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public float introWaitTime;
    public float fadeWaitTime;

    public Image blackImg;

    public FadeObject fadeScr; 

    void Start() 
    {
        fadeScr = this.gameObject.GetComponent<FadeObject>();
        StartCoroutine(Intro());
    }

    private IEnumerator Intro() 
    {
        //play some kind of text
        blackImg.gameObject.GetComponent<FadeObject>().Fade(0, fadeWaitTime);

        yield return new WaitForSeconds(fadeWaitTime);

        GameManager.Instance.ToggleClickableObjects(true, GameManager.Instance.foregroundObjs);
        GameManager.Instance.ToggleClickableObjects(false, GameManager.Instance.backgroundObjs);

        GameManager.Instance.isPauseMenuOpen = false;

        CameraManager.Instance.EnableMovements(true);
    }
}
