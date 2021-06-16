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

    public class GameEventArg: EventArgs
    {
        public uint points { get; set; }
    }

    public class UIEventArg: EventArgs {
        public enum WhichUI {
            HEARTHS,
            COINS
        }
        public uint Coins { get; set; }
        public uint Lives { get; set; }

        public WhichUI UIType { get; set; }
    }
}
