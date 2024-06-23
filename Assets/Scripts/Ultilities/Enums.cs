using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum EPlayerState
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Fall = 3,
        Attack1 = 4,
        Attack2 = 5,
        Attack3 = 6,
        ThrowSword = 7,
        GetHit = 8,
        Die = 9,
    }

    public enum EEnemyState
    {
        Idle = 0,
        Patrol = 1,
        Chase = 2,
        Attack = 3,
        GetHit = 4,
        Die = 5
    }

    public enum ESwordState
    {
        Idle = 0,
        Spin = 1,
        Embedded = 2,
    }

    public enum EPoolable
    {
        Sword = 0,

    }

    public enum EEvents
    {
        SwordOnReceiveDirection = 0,

    }
}
