using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Fall);
        Debug.Log("Player Fall");
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