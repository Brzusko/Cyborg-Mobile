using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventArguments;

public class LoseCondition : MonoBehaviour
{
    private static LoseCondition _instance = null;
    public int Lives { get => _lives;}

    public static LoseCondition Instance {
        get
        {
            if (!_instance) throw new NullReferenceException();
            return _instance;
        }
    }
    public int _lives = 5;
    public GameObject gObject;
    private bool gameOver = false;
    public GameObject bottle;
    public void Restart(){
        _lives = 5;
        gameOver = false;
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

    void Start()
    {
        Notifier.OnBallHit += Notifier_OnBallHit;
    }

    void Notifier_OnBallHit(object sender, EventArguments.BallEventArg e)
    {
        if(e.BallHitT == EventArguments.BallEventArg.BallHitType.WALL)
        {
            _lives -= 1;
            Notifier.OnUIUpdateInvoker(new UIEventArg {
                Lives = _lives,
                UIType = UIEventArg.WhichUI.HEARTHS
            });
            if(_lives == 0 && !gameOver){
                Notifier.GameOver(PointsManager.points);
                gameOver = true;
            }
        }
    }
}
