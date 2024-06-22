using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Attack2);
        _playerSM.AttackEntryTime = Time.time;
        _playerSM.CurrentComboIndex = 2;
        Debug.Log("Player Atk2");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (Time.time - _playerSM.AttackEntryTime < _playerSM.DelayUpdateAttack) return;

        if (CheckIfCanAttack3())
            _playerSM.ChangeState(_playerSM.Attack3State);
    }

    private bool CheckIfCanAttack3()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}