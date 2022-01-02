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
        {
            Debug.Log("Setting a text writer");
            textWriter = this.gameObject.GetComponent<TextWriter>();
        }

        globalFadeWaitTime = CutsceneManager.Instance.globalFadeWaitTime;
        blackImg = CutsceneManager.Instance.blackImg;
    }
    
    public virtual IEnumerator CutsceneWrapper() 
    {
        yield return null;
    }
}
