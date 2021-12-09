using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : MonoBehaviour
{
    public void Whistled()
    {
        CheckForBunnies();
    }

    public void CheckForBunnies()
    {
        //check for bunnies in the range of the whistle to be startled

        foreach(GameObject bunny in GameManager.Instance.foregroundObjs)
        {
            if (bunny != null)
                bunny.gameObject.GetComponent<Bunny>().ChangeState();
        }

        foreach (GameObject bunny in GameManager.Instance.backgroundObjs)
        {
            if (bunny != null)
                bunny.gameObject.GetComponent<Bunny>().ChangeState();
        }
    }


}
