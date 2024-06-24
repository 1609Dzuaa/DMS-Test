using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAttackState : EnemyAttackState
{
    StarStateManager _starSM;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _starSM = (StarStateManager)_enemySM;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        bool isRight = _starSM.IsFacingRight;
        float attackVelo = _starSM.AttackVelo;
        float yVelo = _starSM.Rb2D.velocity.y;

        _enemySM.Rb2D.velocity = new((isRight) ? attackVelo : -attackVelo, yVelo);
    }
}
