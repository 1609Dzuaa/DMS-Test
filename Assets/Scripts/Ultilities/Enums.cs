using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum EPlayerState
    {
        Idle,
        Run,

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
