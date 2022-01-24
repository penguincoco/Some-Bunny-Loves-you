using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundsManager : MonoBehaviour
{
    public GameObject foregroundObjsContainer;
    public GameObject backgroundObjsContainer;

    public List<GameObject> foregroundObjs = new List<GameObject>();
    public List<GameObject> backgroundObjs = new List<GameObject>();

    private static GroundsManager _instance;
    public static GroundsManager Instance { get { return _instance; } }

    public Material m_blurred;
    public Material m_unblurred;

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;


        foregroundObjs = InitializeGround(foregroundObjsContainer);
        backgroundObjs = InitializeGround(backgroundObjsContainer);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.foregroundObjs = this.foregroundObjs;
            GameManager.Instance.backgroundObjs = this.backgroundObjs;
        }
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

    public void ToggleBlur(bool isForegroundActive)
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

    public void RemoveAllBlur() 
    {
        Iterate(m_unblurred, foregroundObjs);
        Iterate(m_unblurred, backgroundObjs);
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
