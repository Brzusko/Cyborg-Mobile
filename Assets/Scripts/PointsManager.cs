using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventArguments;

public class PointsManager : MonoBehaviour
{
    public uint pointValue { get; private set; }
    public static uint points { get; private set; }
    public GameObject textObject;
    public GameObject manager;

    private static PointsManager _instance = null;

    public static PointsManager Instance{
        get
        {
            if (!_instance) throw new NullReferenceException();
            return _instance;
        }
    }

    private void Awake() 
    {

        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);    
    }

    public static void Restart(){
        points = 0;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pointValue = 8;
        Notifier.OnBallHit += Notifier_OnBallHit;
        Notifier.OnGameOver += Notifier_OnGameOver;
    }

    void Notifier_OnBallHit(object sender, EventArguments.BallEventArg e)
    {
        if(e.BallHitT == EventArguments.BallEventArg.BallHitType.PLAYER)
        {
            uint time = (uint)(Mathf.Round(DifficultyLevel.time));
            points += pointValue*(time+1);
            Notifier.OnUIUpdateInvoker(new UIEventArg {
                Coins = points,
                UIType = UIEventArg.WhichUI.COINS
            });
        }
    }

    void Notifier_OnGameOver(object sender, EventArguments.GameEventArg e)
    {
        manager.GetComponent<ScoreManager>().score = e.points;
    }
}
