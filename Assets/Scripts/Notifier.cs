using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Notifier
{
    public static event EventHandler<EventArguments.BallEventArg> OnBallHit;
    public static event EventHandler<EventArguments.GameEventArg> OnGameOver;

    #region Event Risers
    private static void OnBallHitHanlder(EventArguments.BallEventArg e)
    {
        OnBallHit?.Invoke(null, e);
    }
    
    private static void OnGameOverHandler(EventArguments.GameEventArg e)
    {
        OnGameOver?.Invoke(null, e);
    }
    #endregion

    #region Notifiers
    public static void BallHit(EventArguments.BallEventArg.BallHitType ballHitType)
    {
        OnBallHitHanlder(new EventArguments.BallEventArg { BallHitT = ballHitType});
    }

    public static void GameOver(uint finalScore)
    {
        OnGameOverHandler(new EventArguments.GameEventArg {points = finalScore});
    }
    #endregion
}
