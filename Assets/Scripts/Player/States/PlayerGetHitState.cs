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
        SoundsManager.Instance.PlaySfx(Enums.ESounds.GetHitSfx);
        Debug.Log("Player GH");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (Time.time - _playerSM.GetHitEntryTime <= 0.4f) return;

        if (_playerSM.CheckIfCanIdle())
            _playerSM.ChangeState(_playerSM.IdleState);
        else if (_playerSM.CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}