using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Fall);
        _playerSM.Rb2D.gravityScale = Constants.GRAVITY_WHILE_FALL;
        Debug.Log("Player Fall");
    }

    public override void ExitState()
    {
        _playerSM.Rb2D.gravityScale = Constants.INITIAL_GRAVITY; //Reset Grav
    }

    public override void Update()
    {
        if (_playerSM.CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
        else if (_playerSM.CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
    }

    public override void FixedUpdate()
    {
        if (_playerSM.DirX != 0)
            _playerSM.Rb2D.velocity = new Vector2(_playerSM.DirX * _playerSM.Velo, _playerSM.Rb2D.velocity.y);
    }
}