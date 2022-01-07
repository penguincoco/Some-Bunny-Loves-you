using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public float globalFadeWaitTime;
    public Image blackImg;
    public TextWriter textWriter;

    public void Start() 
    {
        if (this.gameObject.GetComponent<TextWriter>() != null) 
            textWriter = this.gameObject.GetComponent<TextWriter>();

        globalFadeWaitTime = CutsceneManager.Instance.globalFadeWaitTime;
        blackImg = CutsceneManager.Instance.blackImg;
    }

    public virtual void CutsceneWrapper()
    {
        StartCoroutine(CutsceneSequence());
    }
    
    public virtual IEnumerator CutsceneSequence() 
    {
        yield return null;
    }

    public virtual void Reset() 
    {

    }
}
