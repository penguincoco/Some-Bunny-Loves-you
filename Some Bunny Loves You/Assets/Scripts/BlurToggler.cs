using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurToggler : MonoBehaviour
{
    public Material m_blurred;
    public Material m_unblurred;

    public void ToggleBlur(bool isForegroundActive, List<GameObject> foregroundObjs, List<GameObject> backgroundObjs) 
    {
        if (isForegroundActive) 
        {
            Iterate(m_unblurred, foregroundObjs);
            Iterate(m_blurred, backgroundObjs); 
        }
        else
        {
            Iterate(m_blurred, foregroundObjs);
            Iterate(m_unblurred, backgroundObjs);
        }
    }

    private void Iterate(Material mat, List<GameObject> objs) 
    {
        foreach (GameObject obj in objs) 
        {
            if (obj != null) 
                obj.gameObject.GetComponent<SpriteRenderer>().material = mat;
        }
    }
}
