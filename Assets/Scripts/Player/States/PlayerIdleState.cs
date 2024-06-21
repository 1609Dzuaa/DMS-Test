using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Rb2D.velocity = Vector2.zero;
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Idle);
        Debug.Log("Player Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (CheckIfCanJump())
            _playerSM.ChangeState(_playerSM.JumpState);
        else if (CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
        else
            CheckIfCanAttack(_playerSM.ComboIndex);
    }

    private void CheckIfCanAttack(int comboIndex)
    {
        switch (comboIndex)
        {
            case 0:
                if (Input.GetMouseButtonDown(0))
                {
                    _playerSM.ChangeState(_playerSM.Attack1State);
                    _playerSM.ComboIndex += 1;
                }
                break;

            case 1:
                if (Time.time - _playerSM.AttackEntryTime <= _playerSM.AllowComboDuration
                    && Input.GetMouseButtonDown(0))
                {
                    _playerSM.ChangeState(_playerSM.Attack2State);
                    _playerSM.ComboIndex += 1;
                }
                else if(Time.time - _playerSM.AttackEntryTime > _playerSM.AllowComboDuration)
                    _playerSM.ComboIndex = 0;
                break;

            case 2:
                if (Time.time - _playerSM.AttackEntryTime <= _playerSM.AllowComboDuration
                    && Input.GetMouseButtonDown(0))
                {
                    _playerSM.ChangeState(_playerSM.Attack3State);
                    _playerSM.ComboIndex = 0;
                }
                else if (Time.time - _playerSM.AttackEntryTime > _playerSM.AllowComboDuration)
                    _playerSM.ComboIndex = 0;
                break;
        }
        Debug.Log("Combo: " + _playerSM.ComboIndex);
    }

    private bool CheckIfCanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && _playerSM.GroundDetected;
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
