using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    sr.color = Color.red;
        //}
    }

    public void SwapSprite(int indexToSwapTo)
    {
        sr.sprite = sprites[indexToSwapTo];
    }
}
