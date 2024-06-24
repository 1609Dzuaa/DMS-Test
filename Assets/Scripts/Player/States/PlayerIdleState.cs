using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Rb2D.velocity = Vector2.zero;
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Idle);
        //Debug.Log("Player Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (_playerSM.CheckIfCanThrowSword())
            _playerSM.ChangeState(_playerSM.ThrowState);
        else if (_playerSM.CheckIfCanJump())
            _playerSM.ChangeState(_playerSM.JumpState);
        else if (_playerSM.CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
        else if (_playerSM.CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
         else if (_playerSM.CheckIfCanAttack(_playerSM.Attack2State.EntryTime, false))
            _playerSM.ChangeState(_playerSM.Attack3State);
        else if (_playerSM.CheckIfCanAttack(_playerSM.Attack1State.EntryTime, false))
            _playerSM.ChangeState(_playerSM.Attack2State);
        else if (_playerSM.CheckIfCanAttack(0, true))
            _playerSM.ChangeState(_playerSM.Attack1State);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
