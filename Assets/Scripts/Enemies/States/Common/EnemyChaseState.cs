using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _enemySM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EEnemyState.Chase);
        //Debug.Log("Enemy Chase");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        HandleFlipTowardsPlayer();

        if (CheckIfCanAttack())
            _enemySM.ChangeState(_enemySM.AttackState);
        else if(CheckIfCanIdle())
            _enemySM.ChangeState(_enemySM.IdleState);
    }

    protected virtual bool CheckIfCanAttack()
    {
        Vector2 currentPos = _enemySM.transform.position;
        Vector2 playerPos = _enemySM.PlayerRef.position;
        float attackableDist = _enemySM.GetEnemySO.AttackableRange;

        return _enemySM.PlayerDetected && Vector2.Distance(currentPos, playerPos) <= attackableDist;
    }

    protected virtual bool CheckIfCanIdle()
    {
        return !_enemySM.PlayerDetected;
    }

    protected void HandleFlipTowardsPlayer()
    {
        float playerPosX = _enemySM.PlayerRef.transform.position.x;
        float currentPosX = _enemySM.transform.position.x;
        bool isRight = _enemySM.IsFacingRight;

        if (currentPosX > playerPosX + Constants.FLIPABLE_OFFSET && isRight)
            _enemySM.FlipSprite();
        else if (currentPosX < playerPosX - Constants.FLIPABLE_OFFSET && !isRight)
            _enemySM.FlipSprite();
    }

    public override void FixedUpdate()
    {
        //Move = velo thay vì MoveTowards cho đỡ bug
        float chaseSpeed = _enemySM.GetEnemySO.ChaseVelo;
        float yVelo = _enemySM.Rb2D.velocity.y;
        bool isRight = _enemySM.IsFacingRight;

        _enemySM.Rb2D.velocity = new((isRight) ? chaseSpeed : -chaseSpeed, yVelo);
    }
}
