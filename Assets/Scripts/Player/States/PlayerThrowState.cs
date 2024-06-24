using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.ThrowSword);
        _playerSM.Anim.SetBool(Constants.SWORD_PARAM, false);
        _playerSM.HasSword = false;
        Debug.Log("Player Throw");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (_playerSM.CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
        else if (_playerSM.CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
        else if (_playerSM.CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}