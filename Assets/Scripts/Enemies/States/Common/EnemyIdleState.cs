using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    protected float _entryTime;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _enemySM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EEnemyState.Idle);
        _enemySM.EntryTime = Time.time;
        _enemySM.Rb2D.velocity = Vector2.zero;
        _entryTime = Time.time;
        Debug.Log("Enemy Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        //Cho TH chạy hết animation attack r mới cho update
        if (Time.time - _entryTime <= 0.75f) return;

        if (CheckIfCanAttack())
            _enemySM.ChangeState(_enemySM.AttackState);
        else if (CheckIfCanChase())
            _enemySM.ChangeState(_enemySM.ChaseState);
        else if (CheckIfCanPatrol())
            _enemySM.ChangeState(_enemySM.PatrolState);
    }

    protected bool CheckIfCanAttack()
    {
        Vector2 currentPos = _enemySM.transform.position;
        Vector2 playerPos = _enemySM.PlayerRef.position;
        float attackableDist = _enemySM.GetEnemySO.AttackableRange;

        return _enemySM.PlayerDetected && Vector2.Distance(currentPos, playerPos) <= attackableDist;
    }

    private bool CheckIfCanPatrol()
    {
        return Time.time - _enemySM.EntryTime >= _enemySM.GetEnemySO.RestTime;
    }

    private bool CheckIfCanChase()
    {
        Vector2 currentPos = _enemySM.transform.position;
        Vector2 playerPos = _enemySM.PlayerRef.position;
        float attackableRange = _enemySM.GetEnemySO.AttackableRange;

        return _enemySM.PlayerDetected && Vector2.Distance(currentPos, playerPos) > attackableRange;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
