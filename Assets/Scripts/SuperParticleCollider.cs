using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArguments;

public class SuperParticleCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Player") Notifier.BallHit(BallEventArg.BallHitType.PLAYER);
        else Notifier.BallHit(BallEventArg.BallHitType.WALL);
    }
}
