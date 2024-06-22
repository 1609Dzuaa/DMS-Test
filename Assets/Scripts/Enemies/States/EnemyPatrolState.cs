using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    bool _Flipped;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _enemySM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EEnemyState.Patrol);
        _enemySM.EntryTime = Time.time;
        Debug.Log("Enemy PT");
    }

    public override void ExitState()
    {
        _Flipped = false;
    }

    public override void Update()
    {
        if (CheckIfCanFlip())
        {
            _enemySM.FlipSprite();
            _Flipped = true;
        }

        if (CheckIfCanRest())
            _enemySM.ChangeState(_enemySM.IdleState);
    }

    private bool CheckIfCanRest()
    {
        return Time.time - _enemySM.EntryTime >= _enemySM.GetEnemySO.PatrolTime;
    }

    private bool CheckIfCanFlip()
    {
        return !_enemySM.GroundDetected && !_Flipped || _enemySM.WallDetected && !_Flipped;
    }

    public override void FixedUpdate()
    {
        float patrolVelo = _enemySM.GetEnemySO.PatrolVelo;
        float currentVeloY = _enemySM.Rb2D.velocity.y;
        _enemySM.Rb2D.velocity = new((_enemySM.IsFacingRight) ? patrolVelo : -patrolVelo, currentVeloY);
    }
}
