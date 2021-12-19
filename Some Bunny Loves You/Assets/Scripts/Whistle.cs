using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : MonoBehaviour
{
    public Collider2D whistleBoundaryBox;
    public List<Collider2D> bunniesInRange;

    public void Whistled()
    {
        CheckForBunnies();
    }

    public void CheckForBunnies()
    {
        //bunniesInRange = whistleBoundaryBox.gameObject.GetComponent<GetObjectsInCollider>().GetColliders();
        //Debug.Log(bunniesInRange.Count);

        //foreach(Collider2D bunny in bunniesInRange)
        //{
        //    if (bunny != null && bunny.gameObject.GetComponent<Bunny>() != null)
        //        bunny.gameObject.GetComponent<Bunny>().ChangeState();
        //}

        //check for bunnies in the range of the whistle to be startled

        //foreach (GameObject bunny in GameManager.Instance.foregroundObjs)
        //    {
        //        if (bunny != null && bunny.gameObject.GetComponent<Bunny>() != null)
        //            bunny.gameObject.GetComponent<Bunny>().ChangeState();
        //    }

        //foreach (GameObject bunny in GameManager.Instance.backgroundObjs)
        //{
        //    if (bunny != null && bunny.gameObject.GetComponent<Bunny>() != null)
        //        bunny.gameObject.GetComponent<Bunny>().ChangeState();
        //}

    }
}
