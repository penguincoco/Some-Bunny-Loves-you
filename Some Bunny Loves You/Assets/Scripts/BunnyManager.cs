using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyManager : MonoBehaviour
{
    public GameObject bunnyPrefab;

    public float bunnyAlertTimer;

    private static BunnyManager _instance;
    public static BunnyManager Instance { get { return _instance; } }

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

        SpawnBunnies();
    }

    private void Start()
    {
        
    }

    private void SpawnBunnies()
    {

    }

    public float GetBunnyAlertTimer()
    {
        return bunnyAlertTimer;
    }
}
