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
        CoinVFX = 1,
        PotionVFX = 2,  
        SkullVFX = 3,
    }

    //Tạo 1 event khi quái chết thì thông báo cho kiếm khỏi nhận parent (nếu lỡ bị ghim vào quái)
    public enum EEvents
    {
        SwordOnReceiveDirection = 0,
        PlayerOnReceiveDamageBuff = 1,
        PlayerOnDeDamageBuff = 2,
    }

    public enum EBuffs
    {
        Speed = 0,
        Health = 1,
        Damage = 2,
    }

    public enum ESounds
    {
        RunSfx = 0,
        JumpSfx = 1,
        Attack1Sfx = 2,
        Attack2Sfx = 3,
        Attack3Sfx = 4,
        DieSfx = 5,
        GetHitSfx = 6,
        COinSfx = 7,
        PotionSfx = 8,


    }

    public enum SHaders
    {
        CloudSd = 0,
    }
}
