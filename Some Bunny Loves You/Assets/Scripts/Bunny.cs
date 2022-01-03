using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour
{
    public GameObject collider;

    public SpriteRenderer sr;

    FiniteStateMachine<Bunny> bunnySM;

    public Sprite[] bunnyRestingSprites;
    public Sprite[] bunnyStateSprites;

    public float alertTimer;
    [SerializeField]private string bunnyState;

    [SerializeField]private int bunnyPointVal;

    public Material bunny_unblurred; 
    public Material bunny_blurred; 

    // Start is called before the first frame update
    void Start()
    {
        bunnySM = new FiniteStateMachine<Bunny>(this);
        bunnySM.TransitionTo<Resting>();

        InitializeBunny();
    }

    private void InitializeBunny()
    {
        if (BunnyManager.Instance != null)
            alertTimer = BunnyManager.Instance.GetBunnyAlertTimer();

        sr = this.gameObject.GetComponent<SpriteRenderer>();
        bunnyState = "Resting";
        
        //give it a random layer 
        // if (sr.sortingLayerName.Equals("background") && GameManager.Instance != null) 
        //     GameManager.Instance.backgroundObjs.Add(this.gameObject);
        // if (sr.sortingLayerName.Equals("foreground") && GameManager.Instance != null) 
        //     GameManager.Instance.foregroundObjs.Add(this.gameObject);

        //give it a random location
        // gameObject.transform.position = new Vector2(Random.Range(-5,35), Random.Range(-5,5));

        // //give it a random layer
        // if (Random.Range(0, 2) == 1)
        // {
        //     this.gameObject.layer = 6;
        //     GameManager.Instance.backgroundObjs.Add(this.gameObject);
        //     sr.material = bunny_blurred;
        //     sr.sortingLayerID = SortingLayer.NameToID("background");
        // }
        // else
        // {
        //     this.gameObject.layer = 7;
        //     GameManager.Instance.foregroundObjs.Add(this.gameObject);
        //     sr.material = bunny_unblurred;
        //     sr.sortingLayerID = SortingLayer.NameToID("foreground");
        // }

        collider = this.gameObject.transform.GetChild(0).gameObject;

        bunnyStateSprites[0] = bunnyRestingSprites[Random.Range(0, bunnyRestingSprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        bunnySM.Update();
    }

    public void ChangeState()
    {
        if (bunnySM.CurrentState.GetType() == typeof(Resting))
            bunnySM.TransitionTo<Alert>();
        if (bunnySM.CurrentState.GetType() == typeof(Alert))
            bunnySM.TransitionTo<Running>();

        //if (bunnySM.CurrentState == Resting || bunnySM.CurrentState == Resting)
        //  bunnySM.TransitionTo<Alert>();

        //if (bunnyState.Equals("Resting"))
        //    bunnySM.TransitionTo<Alert>();
        //if (bunnyState.Equals("alert"))
        //    bunnySM.TransitionTo<Running>();
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }

    public int GetBunnyPointVal()
    {
        return bunnyPointVal;
    }





    private class Resting : FiniteStateMachine<Bunny>.State
    {
        public override void OnEnter()
        {
            Context.bunnyState = "Resting";
            Context.bunnyPointVal = 1;
            Context.sr.sprite = Context.bunnyStateSprites[0];
        }

        public override void StateCheck()
        {
            
        }

        public override void Update()
        {
        }

        public override void OnExit()
        {
        }
    }

    //private class Resting : FiniteStateMachine<Bunny>.State { }

    private class Alert : FiniteStateMachine<Bunny>.State {
        float timer;

        public override void OnEnter()
        {
            Context.sr.color = Color.red;
            timer = Context.alertTimer;
            Context.bunnyState = "alert";
            Context.bunnyPointVal = 2; 
            Context.sr.sprite = Context.bunnyStateSprites[0];
        }

        public override void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                TransitionTo<Resting>();
            }
        }

        public override void OnExit()
        {
            Context.sr.color = Color.white;
        }
    }

    private class Running : FiniteStateMachine<Bunny>.State {
        float runTimer = 1f;
        public override void OnEnter()
        {
            Context.sr.color = Color.green;
            Context.bunnyPointVal = 3;
        }

        public override void Update()
        {
            runTimer -= Time.deltaTime;

            if (runTimer <= 0)
            {
                Context.DestroyObj();
            }
        }
    } 
}
