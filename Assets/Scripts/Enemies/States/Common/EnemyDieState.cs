using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _enemySM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EEnemyState.Die);
        _enemySM.Rb2D.velocity = Vector2.zero;
        _enemySM.HPBar.SetActive(false);
        Debug.Log("Enemy Die");
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
        base.FixedUpdate();
    }
}
