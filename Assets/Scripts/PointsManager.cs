using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public uint pointValue { get; private set; }
    public static uint points { get; private set; }
    public GameObject textObject;
    public GameObject manager;

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
            textObject.GetComponent<Text>().text = points.ToString();
            
        }
    }

    void Notifier_OnGameOver(object sender, EventArguments.GameEventArg e)
    {
        manager.GetComponent<ScoreManager>().score = e.points;
    }
}
