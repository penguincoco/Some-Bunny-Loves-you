using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    public Image[] keySprites;
    public Image whistleButtonImg;

    public Color unlitColour;

    public float whistleLightupTime;

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public void LightUpSprite(bool wPressed) 
    {
        if (wPressed)
        {
            keySprites[0].color = Color.white;
            keySprites[1].color = unlitColour;
        }
        else
        {
            keySprites[0].color = unlitColour;
            keySprites[1].color = Color.white;
        }
    }

    public void LightUpWhistle()
    {
        StartCoroutine(FlashSprite(whistleButtonImg, whistleLightupTime));
    }

    public void LightUpSprite(Image img, float lightupTime)
    {
        StartCoroutine(FlashSprite(img, lightupTime));
    }

    public IEnumerator FlashSprite(Image img, float time)
    {
        img.color = Color.white;

        yield return new WaitForSeconds(time);

        img.color = unlitColour;
    }

    public void ResetSprites(Image[] imgs) 
    {
        foreach(Image img in imgs)
            img.color = unlitColour;
    }

}
