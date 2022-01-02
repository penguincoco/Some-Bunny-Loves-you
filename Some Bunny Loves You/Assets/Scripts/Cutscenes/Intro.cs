using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : Cutscene
{
    public Color nextColor; 

    public override IEnumerator CutsceneWrapper()
    {
        yield return new WaitForSeconds(globalFadeWaitTime + 2);
        //play some kind of text
        //blackImg.gameObject.GetComponent<FadeObject>().Fade(0, globalFadeWaitTime);
        blackImg.gameObject.GetComponent<FadeObject>().FadeColorsWrapper(blackImg.gameObject.GetComponent<Image>().color, nextColor, globalFadeWaitTime);

        yield return new WaitForSeconds(globalFadeWaitTime + 2);

        GameManager.Instance.ToggleClickableObjects(true, GameManager.Instance.foregroundObjs);
        GameManager.Instance.ToggleClickableObjects(false, GameManager.Instance.backgroundObjs);

        // yield return new WaitForSeconds

        GameManager.Instance.isPauseMenuOpen = false;

        CameraManager.Instance.EnableMovements(true);

        blackImg.enabled = false;
        textWriter.ClearText();
    }
}
