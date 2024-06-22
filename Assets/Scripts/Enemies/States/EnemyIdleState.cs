using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _enemySM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EEnemyState.Idle);
        _enemySM.EntryTime = Time.time;
        _enemySM.Rb2D.velocity = Vector2.zero;
        Debug.Log("Enemy Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (CheckIfCanPatrol())
            _enemySM.ChangeState(_enemySM.PatrolState);
    }

    private bool CheckIfCanPatrol()
    {
        return Time.time - _enemySM.EntryTime >= _enemySM.GetEnemySO.RestTime;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
