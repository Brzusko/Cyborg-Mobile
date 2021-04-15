using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Notifier
{
    public static event EventHandler<EventArguments.BallEventArg> OnBallHit;

    #region Event Risers
    private static void OnBallHitHanlder(EventArguments.BallEventArg e)
    {
        OnBallHit?.Invoke(null, e);
    }
    #endregion

    #region Notifiers
    public static void BallHit(EventArguments.BallEventArg.BallHitType ballHitType)
    {
        OnBallHitHanlder(new EventArguments.BallEventArg { BallHitT = ballHitType});
    }
    #endregion
}
