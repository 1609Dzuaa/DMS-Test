using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1State : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Attack1);
        _playerSM.AttackEntryTime = Time.time;
        _playerSM.CurrentComboIndex = 1;
        Debug.Log("Player Atk1");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (Time.time - _playerSM.AttackEntryTime < _playerSM.DelayUpdateAttack) return;

        if (CheckIfCanAttack2())
            _playerSM.ChangeState(_playerSM.Attack2State);
    }

    private bool CheckIfCanAttack2()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}