using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapCanvases : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2; 

    public void ActivateCanvas()  
    {
        if (canvas1.activeSelf) 
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
        }
        else 
        {
             canvas1.SetActive(true);
            canvas2.SetActive(false);
        }
    }
}
