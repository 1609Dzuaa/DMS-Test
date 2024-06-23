using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHitState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.GetHit);
        _playerSM.GetHitEntryTime = Time.time;
        Debug.Log("Player GH");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (Time.time - _playerSM.GetHitEntryTime <= 0.4f) return;

        if (CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
        else if (CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
    }

    private bool CheckIfCanIdle()
    {
        return Mathf.Abs(_playerSM.DirX) == 0.0f && _playerSM.GroundDetected;
    }

    private bool CheckIfCanRun()
    {
        return _playerSM.DirX != 0 && _playerSM.GroundDetected;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}