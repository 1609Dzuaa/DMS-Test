using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Run);
        SoundsManager.Instance.PlaySfx(Enums.ESounds.RunSfx);
        Debug.Log("Player Run");
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
        else if (_playerSM.CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
        else if (_playerSM.CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
        else if (_playerSM.CheckIfCanAttack(_playerSM.Attack2State.EntryTime, false))
            _playerSM.ChangeState(_playerSM.Attack3State);
        else if (_playerSM.CheckIfCanAttack(_playerSM.Attack1State.EntryTime, false))
            _playerSM.ChangeState(_playerSM.Attack2State);
        else if (_playerSM.CheckIfCanAttack(0, true))
            _playerSM.ChangeState(_playerSM.Attack1State);
    }

    public override void FixedUpdate()
    {
        _playerSM.Rb2D.velocity = new Vector2((_playerSM.IsFacingRight) ? _playerSM.Velo : -_playerSM.Velo, _playerSM.Rb2D.velocity.y);
    }
}
