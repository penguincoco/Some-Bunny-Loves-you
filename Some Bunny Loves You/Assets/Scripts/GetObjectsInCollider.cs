using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectsInCollider : MonoBehaviour
{
    private List<Collider2D> colliders = new List<Collider2D>();
    public List<Collider2D> GetColliders() { return colliders; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other))
            colliders.Add(other);
    }
}
