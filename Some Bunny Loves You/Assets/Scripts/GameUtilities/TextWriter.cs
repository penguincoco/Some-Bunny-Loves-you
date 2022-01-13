 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public float timePerChar;
    public float timer;
    public TMP_Text uiText;
    public string textToWrite;
    private int characterIndex;

    // public List<string> dialogue;
    public string[] dialogue;
    public TextAsset dialogueFile;

    public Text showDialogue;

    public int dialogueIndex;

    void Start()
    {
        dialogueIndex = 0;

        if (dialogueFile != null)
            Parse();
    }

    private void Parse()
    {
        string text = dialogueFile.text;

        dialogue = text.Split('\n');

        // foreach (string line in dialogue)
        // {
        //     Debug.Log(line);
        // }

        textToWrite = dialogue[0];
    }
    
    void Update() 
    {
        if (uiText != null) 
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && characterIndex < textToWrite.Length)
            {
                timer += timePerChar;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);
            }
        }

        // if (uiText.text.Length >= textToWrite.Length) 
        // { 
        //     uiText.text = "";
        // }
    }

    public void ClearText() 
    {
        uiText.text = "";
    }

    public void Reset() 
    {
        ClearText();
        dialogueIndex = 0;
        textToWrite = dialogue[0];
        uiText.text = "";
        timer = 0f;
        characterIndex = 0;
    } 

    public void SetNextText() 
    {
        ClearText();
        dialogueIndex++;
        if (dialogueIndex < dialogue.Length)
            textToWrite = dialogue[dialogueIndex];
        timer = 0f;
        characterIndex = 0;
    }

    //gets the length of dialogue[] so we don't get an OutOfBounds exception
    public int GetLineCount()
    {
        return dialogue.Length;
    }

    public void ShowDialogue(int index)
    {
        //only change the dialogue when the line actually had dialogue, not just empty
        if (!dialogue[index].Equals(""))
            showDialogue.text = dialogue[index];
    }
}

