using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyManager : MonoBehaviour
{
    public GameObject bunnyPrefab;
    public int numberOfBunnies;
    public float bunnyAlertTimer;

    public GameObject[] allBunnies;

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

    void Start()
    {
        allBunnies = GameObject.FindGameObjectsWithTag("Bunny");
    }

    private void SpawnBunnies()
    {
        for (int i = 0; i < numberOfBunnies; i++) 
            Instantiate(bunnyPrefab);
    }

    public float GetBunnyAlertTimer()
    {
        return bunnyAlertTimer;
    }
}
