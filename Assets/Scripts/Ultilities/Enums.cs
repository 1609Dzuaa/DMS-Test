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
        Idle,
        Run,
        Attack,
        GetHit,
        Die
    }
}
