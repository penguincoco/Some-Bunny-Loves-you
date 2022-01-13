using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class FadeObject : MonoBehaviour
{
    public Color colourToFadeTo;
    public float fadeTime;

    public void Fade(int fadeDirection) 
    {
        FadeUIWrapper(this.gameObject.GetComponent<Image>(), fadeDirection, this.fadeTime);
    }
    
    public void Fade(int fadeDirection, float fadeTime) 
    {
        FadeUIWrapper(this.gameObject.GetComponent<Image>(), fadeDirection, fadeTime);
    }

    public void FadeUIWrapper(Graphic objToFade, int fadeDirection, float fadeTime)
    {
        StartCoroutine(FadeUI(objToFade, fadeDirection, fadeTime));
    }

    private IEnumerator FadeUI(Graphic objToFade, int fadeDirection, float fadeTime)
    {
        float currTime = 0f;
        Color currColour = objToFade.color;
		objToFade.enabled = true;
        do
        {
            //fading from 0 opacity to full
            if (fadeDirection == 1)
                currColour.a = (currTime / fadeTime);
            //fading from full opacity to 0
            else
                currColour.a = 1 - (currTime / fadeTime);

            objToFade.color = currColour;

            yield return null;

            currTime += Time.deltaTime;
        } while (currTime <= fadeTime);

		if(fadeDirection == 0)
			objToFade.enabled = false;
    }

    public void FadeColorsWrapper(Graphic objToFade, Color currColor, Color nextColor, float time) 
    {
        StartCoroutine(FadeColors(objToFade, currColor, nextColor, time));
    }

    public void FadeColorsWrapper(Color currColor, Color nextColor, float time)
    {
        StartCoroutine(FadeColors(this.gameObject.GetComponent<Image>(), currColor, nextColor, time));
    }

    private IEnumerator FadeColors(Graphic objToFade, Color currColor, Color nextColor, float time)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            objToFade.color = Color.Lerp(currColor, nextColor, (elapsedTime / time));
            yield return null;
        }
    }

    //public void FadeTextWrapper(TMP_Text text, int fadeDirection, float fadeTime)
    //{
    //    StartCoroutine(FadeUI(text, fadeDirection, fadeTime));
    //}
}
