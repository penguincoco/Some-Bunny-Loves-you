using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleRangeCheck : MonoBehaviour
{
    //List<Collider2D> bunniesInRange;
    //Collider2D[] bunniesInRange;
    Collider[] bunniesInRange;
    public LayerMask m_LayerMask;
    public ContactFilter2D m_contactFilter;
    bool m_started;
    public int bunnyInRangeCount = 0;

    public float whistleRadius; 

    private void Start()
    {
        m_started = true;
        //bunniesInRange = new List<Collider2D>();
    }

    public void CheckForBunnies()
    {
        Debug.Log("whistling");
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.

        bunniesInRange = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
       // bunnyInRangeCount = Physics2D.OverlapCircle(gameObject.transform.position, 3f, m_contactFilter, bunniesInRange);
        //bunnyInRangeCount = Physics2D.OverlapCircle(gameObject.transform.position, 10f, m_contactFilter, bunniesInRange);

        Debug.Log(bunniesInRange.Length);

        //foreach (Collider2D bunny in bunniesInRange)
        foreach (Collider bunny in bunniesInRange)
        {
            if (bunny != null && bunny.transform.parent.gameObject.GetComponent<Bunny>() != null)
            {
                Debug.Log("changing");
                bunny.transform.parent.gameObject.GetComponent<Bunny>().ChangeState();
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    bunniesInRange.Add(collision);
    //    Debug.Log(bunniesInRange.Count);
    //}
    
    //private void FixedUpdate()
    //{
    //    bunniesInRange = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
    //    int i = 0;
    //    Debug.Log(bunniesInRange.Length);
    //    //Check when there is a new collider coming into contact with the box
    //    while (i < bunniesInRange.Length)
    //    {
    //        Debug.Log("Hit : " + bunniesInRange[i].name + i);
    //        //Increase the number of Colliders in the array
    //        i++;
    //    }
    //}

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}