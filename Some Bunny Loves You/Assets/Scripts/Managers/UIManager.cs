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

    public Color litColour;

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
        Debug.Log("a button was pressed");
        if (wPressed)
        {
            keySprites[0].color = Color.white;
            keySprites[1].color = litColour;
        }
        else
        {
            keySprites[0].color = litColour;
            keySprites[1].color = Color.white;
        }
    }

    public void LightUpWhistle()
    {
        StartCoroutine(FlashSprite(whistleButtonImg));
    }

    public IEnumerator FlashSprite(Image img)
    {
        img.color = litColour;

        yield return new WaitForSeconds(0.5f);

        img.color = Color.white;
    }

}
