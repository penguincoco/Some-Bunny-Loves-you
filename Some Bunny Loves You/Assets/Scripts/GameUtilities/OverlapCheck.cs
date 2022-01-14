using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCheck : MonoBehaviour
{
    private bool isOverlapping;

    void Update() 
    {
        if (isOverlapping) 
        {
            Debug.Log("was overlapping with anoter object, destroying this object");
            Destroy(this.gameObject);
            if (this.transform.parent.gameObject != null) 
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
        else 
        {
            Debug.Log("was not overlapping, destroying this script");
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D otherObj) 
    {
        Debug.Log("object was triggered by somethign");
        if (otherObj.gameObject.tag.Equals("Overlap Object"))
            isOverlapping = true;
    }
}
