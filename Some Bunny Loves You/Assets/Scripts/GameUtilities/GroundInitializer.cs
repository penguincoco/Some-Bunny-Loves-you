using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInitializer : MonoBehaviour
{
    // public GameObject foregroundObjs
    public List<GameObject> listToReturn;

    public List<GameObject> InitializeGround(GameObject objContainer) 
    {
        listToReturn.Clear();

        foreach (Transform child in objContainer.transform) 
            listToReturn.Add(child.gameObject);

        // foreach (GameObject obj in listToReturn)
        //     Debug.Log("from container" + objContainer + "and name" + obj.name);

        return listToReturn;
    }
}
