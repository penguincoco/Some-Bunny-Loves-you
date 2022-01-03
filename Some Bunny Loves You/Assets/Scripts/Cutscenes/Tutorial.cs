using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : Cutscene
{
    public GameObject gm;

    public float pauseOnTextBuffer;
    public float timePerLine;
    public float initialPauseTime;

    private float pauseTime;

    private int imgIndex = 0;

    public Image[] buttonSprites;

    // public GameObject foregroundObjsContainer;
    // public GameObject backgroundObjsContainer;

    // [SerializeField]private List<GameObject> foregroundObjs = new List<GameObject>();
    // [SerializeField]private List<GameObject> backgroundObjs = new List<GameObject>();

    private Dictionary<int, System.Action> tutorialIndexFunctionDict = new Dictionary<int, System.Action>();

    void Start() 
    {
        base.Start();
        StartCoroutine(CutsceneWrapper());

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
    }

    public override IEnumerator CutsceneWrapper() 
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
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex], pauseTime);
        UIManager.Instance.LightUpSprite(buttonSprites[imgIndex + 1], pauseTime);
    }
}
