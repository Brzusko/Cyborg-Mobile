using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public uint pointValue { get; private set; }
    public static uint points { get; private set; }
    public Text scoreText;
    
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
            scoreText.text = "Score = "+points.ToString();
        }
    }

    void Notifier_OnGameOver(object sender, EventArguments.GameEventArg e)
    {
        ScoreManager.Instance.score = e.points;
    }
}
