using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInitializer : MonoBehaviour
{
    public GameObject foregroundObjsContainer;
    public GameObject backgroundObjsContainer;

    public List<GameObject> foregroundObjs = new List<GameObject>();
    public List<GameObject> backgroundObjs = new List<GameObject>();

    void Awake() 
    {
        foregroundObjs = InitializeGround(foregroundObjsContainer);
        backgroundObjs = InitializeGround(backgroundObjsContainer);
    }

    public List<GameObject> InitializeGround(GameObject objContainer) 
    {
        List<GameObject> listToReturn = new List<GameObject>();

        foreach (Transform child in objContainer.transform) 
            listToReturn.Add(child.gameObject);

        // foreach (GameObject obj in listToReturn)
        //     Debug.Log("from container" + objContainer + "and name" + obj.name);

        return listToReturn;
    }
}
