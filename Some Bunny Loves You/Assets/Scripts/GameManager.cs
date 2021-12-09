using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text bunnyCounterTxt;
    private int bunnyCounter;

    [SerializeField] private FocusSwitcher focus;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }       

    public GameObject foregroundObjsContainer;
    public GameObject backgroundObjsContainer;

    public List<GameObject> foregroundObjs = new List<GameObject>();
    public List<GameObject> backgroundObjs = new List<GameObject>();

    public Camera focusCam;

    public bool isForegroundActive = true;

    int foregroundLayer;
    int backgroundLayer;

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Debug.Log(foregroundObjs.Count);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            focusCam.cullingMask = 1 << foregroundLayer;

            //enable all clickable objects
            ToggleClickableObjects(true, foregroundObjs);
            ToggleClickableObjects(false, backgroundObjs);

            isForegroundActive = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            focusCam.cullingMask = 1 << backgroundLayer;

            ToggleClickableObjects(false, foregroundObjs);
            ToggleClickableObjects(true, backgroundObjs);

            isForegroundActive = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SetBunnyCounter()
    {
        bunnyCounter++;
        bunnyCounterTxt.text = bunnyCounter.ToString();
    }

    public int GetActiveLayer() 
    {
        //return 0 if foreground is active
        if (isForegroundActive)
            return 0;
        else
            return 1;

        //return 1 if foreground is NOT active
    }

    void Initialize()
    {
        //foreach (Transform child in foregroundObjsContainer.transform)
          //  foregroundObjs.Add(child.gameObject);

        //foreach (Transform child in backgroundObjsContainer.transform)
           // backgroundObjs.Add(child.gameObject);

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
            if (obj != null && obj.gameObject.GetComponent<ClickableObject>() != null)
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
