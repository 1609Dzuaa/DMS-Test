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
        if (CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
    }

    private bool CheckIfCanFall()
    {
        return _playerSM.Rb2D.velocity.y < 0f;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}