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
        if (CheckIfCanFall())
            _playerSM.ChangeState(_playerSM.FallState);
        else if (CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
    }

    private bool CheckIfCanFall()
    {
        return !_playerSM.GroundDetected;
    }

    private bool CheckIfCanIdle()
    {
        return Mathf.Abs(_playerSM.DirX) == 0.0f && _playerSM.GroundDetected;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}