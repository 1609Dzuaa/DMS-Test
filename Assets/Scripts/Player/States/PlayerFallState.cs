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
        if (CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
    }

    private bool CheckIfCanIdle()
    {
        return _playerSM.GroundDetected;
    }

    public override void FixedUpdate()
    {
        if (_playerSM.DirX != 0)
            _playerSM.Rb2D.velocity = new Vector2(_playerSM.DirX * _playerSM.Velo, _playerSM.Rb2D.velocity.y);
    }
}