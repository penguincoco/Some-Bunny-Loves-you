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
    
    void Update() 
    {
        if (uiText != null) 
        {
            timer -= Time.deltaTime;

            if (timer <= 0) 
            {
                timer += timePerChar;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);
            }
        }
    }
}

