using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Intro : Cutscene
{
    public Color nextColor;
    public float pauseTime = 0f;
    public float pauseOnTextBuffer;
    public float initialPauseTime;

    public float pauseBufferTime;

    public TMP_Text uiText;

    public void Start() 
    {
        base.Start();
        this.uiText = textWriter.uiText;
    }

    public override IEnumerator CutsceneSequence()
    {
        yield return new WaitForSeconds(initialPauseTime);

        foreach (string dialogueLine in textWriter.dialogue)
        {
            SetPauseTime();

            yield return new WaitForSeconds(pauseTime + pauseBufferTime);

            textWriter.SetNextText();
        }

        textWriter.uiText.text = textWriter.dialogue[1];
        textWriter.enabled = false;

        yield return new WaitForSeconds(pauseOnTextBuffer);

        float countdownTimer = 3f;

        for (int i = 3; i > 0; i--)
        {
            textWriter.uiText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        blackImg.gameObject.GetComponent<FadeObject>().FadeUIWrapper(textWriter.uiText, 0, globalFadeWaitTime);

        yield return new WaitForSeconds(globalFadeWaitTime);

        //fade the black img
        blackImg.gameObject.GetComponent<FadeObject>().FadeColorsWrapper(blackImg.gameObject.GetComponent<Image>().color, nextColor, globalFadeWaitTime);

        yield return new WaitForSeconds(globalFadeWaitTime + 2);

        StartGame();
    }

    public void StartGame()
    {
        //start the game
        GameManager.Instance.ToggleClickableObjects(true, GameManager.Instance.foregroundObjs);
        GameManager.Instance.ToggleClickableObjects(false, GameManager.Instance.backgroundObjs);

        GameManager.Instance.isPauseMenuOpen = false;

        CameraManager.Instance.EnableMovements(true);

        blackImg.enabled = false;
        textWriter.ClearText();
    }

    public void SetPauseTime()
    {
        float timePerLine = textWriter.timePerChar * textWriter.textToWrite.Length;
        pauseTime = timePerLine + pauseOnTextBuffer;
    }
}
