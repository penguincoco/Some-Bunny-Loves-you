using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float stepSize;
    public List<GameObject> parallaxObjs; 
    public int layerToParallax;
    public bool isParallaxing;

    void Start() 
    {
        if (layerToParallax == 0) 
            parallaxObjs = GameManager.Instance.backgroundObjs;
        if (layerToParallax == 1) 
            parallaxObjs = GameManager.Instance.foregroundObjs;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.isPauseMenuOpen)
        {
        //foreach(GameObject obj in GameManager.Instance.backgroundObjs)
            foreach(GameObject obj in parallaxObjs)
            {
                if (obj != null)
                {
                    Vector3 objPos = obj.transform.position;
                    objPos.x += stepSize;
                    obj.transform.position = objPos;
                }
            }
        }
    }

    public void SetParallaxing(bool isParallaxing) {
        this.isParallaxing = isParallaxing;
    }
}
