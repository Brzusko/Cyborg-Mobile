using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventArguments
{
    public class BallEventArg: EventArgs
    {
        public enum BallHitType
        {
            NONE,
            PLAYER,
            WALL
        }

        public BallHitType BallHitT { get; set; }
    }
}
