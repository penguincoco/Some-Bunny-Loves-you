using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleRangeCheck : MonoBehaviour
{
    //List<Collider2D> bunniesInRange;
    public Collider2D[] bunniesInRange;
    //Collider[] bunniesInRange;
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
        //bunniesInRange = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        bunniesInRange = Physics2D.OverlapCircleAll(gameObject.transform.position, whistleRadius, m_LayerMask, -100f, 100f);

        Debug.Log(bunniesInRange.Length);

        foreach (Collider2D bunny in bunniesInRange)
        //foreach (Collider bunny in bunniesInRange)
        {
            if (bunny != null && bunny.gameObject.tag.Equals("Bunny Collider"))
            {
                Debug.Log("changing");
                bunny.transform.parent.gameObject.GetComponent<Bunny>().ChangeState();
            }
        }
    }

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
