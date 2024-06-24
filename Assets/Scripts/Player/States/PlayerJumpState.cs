using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Rb2D.velocity = new Vector2(_playerSM.Rb2D.velocity.x, _playerSM.JumpForce);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Jump);
        Debug.Log("Player Jump");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (_playerSM.CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
    }

    public override void FixedUpdate()
    {
        if (_playerSM.DirX != 0)
            _playerSM.Rb2D.velocity = new Vector2(_playerSM.DirX * _playerSM.Velo, _playerSM.Rb2D.velocity.y);
    }
}