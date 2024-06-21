using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Run);
        Debug.Log("Player Run");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (CheckIfCanJump())
            _playerSM.ChangeState(_playerSM.JumpState);
        else if (CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
    }

    private bool CheckIfCanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && _playerSM.GroundDetected;
    }

    private bool CheckIfCanIdle()
    {
        return Mathf.Abs(_playerSM.DirX) < 0.01f && _playerSM.GroundDetected;
    }

    public override void FixedUpdate()
    {
        _playerSM.Rb2D.velocity = new Vector2((_playerSM.IsFacingRight) ? _playerSM.Velo : -_playerSM.Velo, _playerSM.Rb2D.velocity.y);
    }
}
