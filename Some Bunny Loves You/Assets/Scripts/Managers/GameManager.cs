using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPauseMenuOpen = true;
    public GameObject whistleRangeCheckObj;
    
    public TMP_Text bunnyCounterTxt;
    private int bunnyCounter;

    public GameObject foregroundObjsContainer;
    public GameObject backgroundObjsContainer;

    public List<GameObject> foregroundObjs = new List<GameObject>();
    public List<GameObject> backgroundObjs = new List<GameObject>();

    [SerializeField] private FocusSwitcher focus;
    public Camera focusCam;

    public bool isForegroundActive = true;

    int foregroundLayer;
    int backgroundLayer;
    int ignoreRaycastLayer;
    int defaultLayer;

    public bool debugMode;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }   

    private void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (!isPauseMenuOpen)
        {
            GroundToggle();
            Whistle();
        } 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
                PauseMenu(false, true);
            else
                PauseMenu(true, false); 
        }

        if (debugMode)
            DebugKeys();
    }

    public void PauseMenu(bool isPauseMenuOpen, bool areObjectsMoving) 
    {
        this.isPauseMenuOpen = isPauseMenuOpen;

        //CameraMovement.Instance.SetCamMoving(areObjectsMoving);
        CameraManager.Instance.EnableMovements(areObjectsMoving);
        pauseMenu.gameObject.SetActive(isPauseMenuOpen);

        if (isPauseMenuOpen) 
        {
            ToggleClickableObjects(false, foregroundObjs);
            ToggleClickableObjects(false, backgroundObjs);
        }
        else 
        {
            if (isForegroundActive) 
            {
                ToggleClickableObjects(true, foregroundObjs);
                ToggleClickableObjects(false, backgroundObjs);
            }    
            else 
            {
                ToggleClickableObjects(false, foregroundObjs);
                ToggleClickableObjects(true, backgroundObjs);
            }
        }
    }

    public void GroundToggle() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("toggling");
            UIManager.Instance.LightUpSprite(true);
            focusCam.cullingMask = 1 << foregroundLayer;

            //enable all clickable objects
            ToggleClickableObjects(true, foregroundObjs);
            ToggleClickableObjects(false, backgroundObjs);

            isForegroundActive = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            UIManager.Instance.LightUpSprite(false);
            focusCam.cullingMask = 1 << backgroundLayer;

            ToggleClickableObjects(false, foregroundObjs);
            ToggleClickableObjects(true, backgroundObjs);

            isForegroundActive = false;
        }
    }

    public void Whistle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.LightUpWhistle();
            whistleRangeCheckObj.gameObject.GetComponent<WhistleRangeCheck>().CheckForBunnies();
        }
    }

    public void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }

    public void IncreaseBunnyCounter(int points)
    {
        bunnyCounter += points;
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
        ignoreRaycastLayer = LayerMask.NameToLayer("Ignore Raycast");
        defaultLayer = LayerMask.NameToLayer("Default");
        focusCam.cullingMask = 1 << foregroundLayer;

        ToggleClickableObjects(false, foregroundObjs);
        ToggleClickableObjects(false, backgroundObjs);
    }

    public void ToggleClickableObjects(bool toggle, List<GameObject> gameObjs)
    {
        foreach (GameObject obj in gameObjs)
        {
            if (obj != null && obj.gameObject.GetComponent<ClickableObject>() != null)
            {
                if(toggle)
                    obj.gameObject.GetComponent<Bunny>().collider.layer = defaultLayer;
                else
                    obj.gameObject.GetComponent<Bunny>().collider.layer = ignoreRaycastLayer;

                //obj.gameObject.GetComponent<Collider>().enabled = toggle;
                //obj.gameObject.GetComponent<ClickableObject>().enabled = toggle;
            }
        }
    }
}
