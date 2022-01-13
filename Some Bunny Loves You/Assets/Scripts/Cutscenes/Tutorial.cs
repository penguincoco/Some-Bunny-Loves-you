using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : Cutscene
{
    public GameObject gm;

    public float pauseOnTextBuffer;
    public float timePerLine;
    public float initialPauseTime;

    private float pauseTime;

    private int imgIndex = 0;

    public Image[] buttonSprites;

    public List<GameObject> whistleInRangeBunnies = new List<GameObject>();

    public TMP_Text bunnyCounterText;

    public GameObject[] bunniesToDelete;

    private Dictionary<int, System.Action> tutorialIndexFunctionDict = new Dictionary<int, System.Action>();

    void Start() 
    {
        base.Start();
        textWriter.enabled = false;

        // foregroundObjs = gm.gameObject.GetComponent<GroundInitializer>().foregroundObjs;
        // backgroundObjs = gm.gameObject.GetComponent<GroundInitializer>().backgroundObjs;

        // foregroundObjs = gm.gameObject.GetComponent<GroundInitializer>().InitializeGround(foregroundObjsContainer);
        // backgroundObjs = gm.gameObject.GetComponent<GroundInitializer>().InitializeGround(backgroundObjsContainer);

        // foreach(GameObject obj in foregroundObjs) 
        //     Debug.Log(obj.name);
        // foreach (GameObject obj in backgroundObjs)
        //     Debug.Log(obj.name);

        tutorialIndexFunctionDict.Add(0, StepW);
        tutorialIndexFunctionDict.Add(1, StepS);
        tutorialIndexFunctionDict.Add(2, StepClick);
        tutorialIndexFunctionDict.Add(3, StepE);
    }

    public override void CutsceneWrapper() 
    {
        StartCoroutine(CutsceneSequence());
    }

    public override void Reset() 
    {
        textWriter.enabled = false;
        textWriter.Reset();
        gm.gameObject.GetComponent<GroundsManager>().RemoveAllBlur();
        UIManager.Instance.ResetSprites(buttonSprites);

        pauseTime = 0;
        timePerLine = 0;
        imgIndex = 0;
    }

    public override IEnumerator CutsceneSequence() 
    {
        yield return new WaitForSeconds(initialPauseTime);

        textWriter.enabled = true;
        foreach(string dialogueLine in textWriter.dialogue) 
        {
            SetPauseTime();

            if (imgIndex < tutorialIndexFunctionDict.Count)
                tutorialIndexFunctionDict[imgIndex]();

            yield return new WaitForSeconds(pauseTime);

            imgIndex++;
            textWriter.SetNextText();
        }

        yield return null;
    }

    public void SetPauseTime() 
    {
        timePerLine = textWriter.timePerChar * textWriter.textToWrite.Length;
        pauseTime = timePerLine + pauseOnTextBuffer;
    }

    public void StepW() 
    {
        gm.gameObject.GetComponent<GroundsManager>().ToggleBlur(true);
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex], pauseTime);
    }

    public void StepS() 
    {
        gm.gameObject.GetComponent<GroundsManager>().ToggleBlur(false);
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex], pauseTime);
    }

    public void StepClick() 
    {
        StartCoroutine(StepClickIterator());
    }

    private IEnumerator StepClickIterator()
    {
        buttonSprites[imgIndex + 1].enabled = true;

        yield return new WaitForSeconds(1f);

        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex], pauseTime - 1f);
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex + 1], pauseTime - 1f);
        Destroy(bunniesToDelete[0]);
        bunnyCounterText.text = 1.ToString();
    }

    public void StepE() 
    {
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex], pauseTime);

        foreach(GameObject bunny in whistleInRangeBunnies)
        {
            if (bunny != null)
                bunny.gameObject.GetComponent<SpriteSwapper>().SwapSprite(0);
        }
    }
}
