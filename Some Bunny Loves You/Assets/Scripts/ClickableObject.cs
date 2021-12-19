using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string FocusedLayer = "foreground";

    private GameObject currentlyFocused;
    private int previousLayer;


    void OnMouseDown()
    {
        Debug.Log("clicking on bunny");
        GameManager.Instance.IncreaseBunnyCounter(this.gameObject.GetComponent<Bunny>().GetBunnyPointVal());
        Destroy(this.gameObject);
        //SetFocused(this.gameObject);
    }


    //public void SetFocused(GameObject obj)
    //{
    //    // enables this camera and the postProcessingVolume which is the child
    //    gameObject.SetActive(true);

    //    // if something else was focused before reset it
    //    if (currentlyFocused) currentlyFocused.layer = previousLayer;

    //    // store and focus the new object
    //    currentlyFocused = obj;

    //    if (currentlyFocused)
    //    {
    //        previousLayer = currentlyFocused.layer;
    //        currentlyFocused.layer = LayerMask.NameToLayer(FocusedLayer);
    //    }
    //    else
    //    {
    //        // if no object is focused disable the FocusCamera
    //        // and PostProcessingVolume for not wasting rendering resources
    //        gameObject.SetActive(false);
    //    }
    //}

}
