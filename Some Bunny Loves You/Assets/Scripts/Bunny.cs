using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunny : MonoBehaviour
{
    public SpriteRenderer sr;

    FiniteStateMachine<Bunny> bunnySM;

    Sprite[] bunnyStateSprites;

    public float alertTimer;
    private string bunnyState;

    // Start is called before the first frame update
    void Start()
    {
        bunnySM = new FiniteStateMachine<Bunny>(this);
        bunnySM.TransitionTo<Eating>();

        InitializeBunny();
    }

    private void InitializeBunny()
    {
        alertTimer = BunnyManager.Instance.GetBunnyAlertTimer();

        sr = this.gameObject.GetComponent<SpriteRenderer>();
        bunnyState = "eating";

        //give it a random location
        gameObject.transform.position = new Vector2(Random.Range(-5,5), Random.Range(-5,5));

        //give it a random layer
        if (Random.Range(0, 2) == 1)
        {
            this.gameObject.layer = 6;
            GameManager.Instance.backgroundObjs.Add(this.gameObject);
        }
        else
        {
            this.gameObject.layer = 7;
            GameManager.Instance.foregroundObjs.Add(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bunnySM.Update();
    }

    public void ChangeState()
    {
        //if (bunnySM.CurrentState == Eating || bunnySM.CurrentState == Resting)
        //  bunnySM.TransitionTo<Alert>();

        if (bunnyState.Equals("eating"))
            bunnySM.TransitionTo<Alert>();
        if (bunnyState.Equals("alert"))
            bunnySM.TransitionTo<Running>();
    }
   
    public void ChangeState(string changeToState)
    {
        if (changeToState.Equals("eating"))
            bunnySM.TransitionTo<Eating>();
        if (changeToState.Equals("alert"))
            bunnySM.TransitionTo<Alert>();
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }





    private class Eating : FiniteStateMachine<Bunny>.State
    {
        public override void OnEnter()
        {
            Context.bunnyState = "eating";
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
        }

        public override void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                TransitionTo<Eating>();
            }
        }

        public override void OnExit()
        {
            Context.sr.color = Color.white;
        }
    }

    private class Running : FiniteStateMachine<Bunny>.State {
        public override void OnEnter()
        {
            Context.sr.color = Color.green;
            Context.DestroyObj();
        }
    } 
}
