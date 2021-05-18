using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public uint score = 0;
    public uint pointValue = 8;
    public uint hit = 0;

    // Start is called before the first frame update
    void Start()
    {
        Notifier.OnBallHit += Notifier_OnBallHit;
    }

    void Notifier_OnBallHit(object sender, EventArguments.BallEventArg e)
    {
        if(e.BallHitT == EventArguments.BallEventArg.BallHitType.PLAYER)
        {
            hit++;
            uint time = (uint)(Mathf.Round(DifficultyLevel.time));
            score += pointValue*(time+1);
        }
    }
}
