using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FocusSwitcher focus;

    GameObject[] gos;
    public GameObject foregroundObjsContainer;
    public GameObject backgroundObjsContainer;

    public List<GameObject> foregroundObjs = new List<GameObject>();
    public List<GameObject> backgroundObjs = new List<GameObject>();

    public Camera focusCam;

    int foregroundLayer;
    int backgroundLayer;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("toggling up");
            focusCam.cullingMask = 1 << foregroundLayer;

            //enable all clickable objects
            ToggleClickableObjects(true, foregroundObjs);
            ToggleClickableObjects(false, backgroundObjs);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("toggling down");
            focusCam.cullingMask = 1 << backgroundLayer;
        }
    }

    void Initialize()
    {
        foreach (Transform child in foregroundObjsContainer.transform)
            foregroundObjs.Add(child.gameObject);

        foreach (Transform child in backgroundObjsContainer.transform)
            backgroundObjs.Add(child.gameObject);

        foregroundLayer = LayerMask.NameToLayer("foreground");
        backgroundLayer = LayerMask.NameToLayer("background");

        focusCam.cullingMask = 1 << foregroundLayer;

        ToggleClickableObjects(true, foregroundObjs);
        ToggleClickableObjects(false, backgroundObjs);
    }

    void ToggleClickableObjects(bool toggle, List<GameObject> gameObjs)
    {
        foreach (GameObject obj in gameObjs)
        {
            if (obj.gameObject.GetComponent<ClickableObject>() != null)
            {
                obj.gameObject.GetComponent<Collider2D>().enabled = toggle;
                obj.gameObject.GetComponent<ClickableObject>().enabled = toggle;
            }
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        foreach
    //        focus.SetFocused()
    //    }
    //}


    //private void OnMouseEnter()
    //{
    //    focus.SetFocused(gameObject);
    //}

    //private void OnMouseExit()
    //{
    //    // reset the focus
    //    // in the future you should maybe check first
    //    // if this object is actually the focused one currently
    //    focus.SetFocused(null);
    //}
}
