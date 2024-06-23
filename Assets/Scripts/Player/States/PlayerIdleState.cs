using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Rb2D.velocity = Vector2.zero;
        _playerSM.Rb2D.gravityScale = Constants.INITIAL_GRAVITY;
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Idle);
        //Debug.Log("Player Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        if (CheckIfCanThrowSword())
            _playerSM.ChangeState(_playerSM.ThrowState);
        else if (CheckIfCanJump())
            _playerSM.ChangeState(_playerSM.JumpState);
        else if (CheckIfCanRun())
            _playerSM.ChangeState(_playerSM.RunState);
        else
            CheckIfCanAttack();
    }

    private bool CheckIfCanThrowSword()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void CheckIfCanAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_playerSM.CurrentComboIndex == 0) _playerSM.ChangeState(_playerSM.Attack1State);
            else if (Time.time - _playerSM.AttackEntryTime <= _playerSM.AllowComboDuration)
            {
                _playerSM.ChangeState((_playerSM.CurrentComboIndex == 1) ? _playerSM.Attack2State : _playerSM.Attack3State);
            }
            else
                _playerSM.CurrentComboIndex = 0; //Hết thgian combo thì reset CurrentComboIndex về 0
        }
        else
        {
            if (Time.time - _playerSM.AttackEntryTime > _playerSM.AllowComboDuration)
                _playerSM.CurrentComboIndex = 0; //Hết thgian combo thì reset CurrentComboIndex về 0
        }
        //Debug.Log("Combo: " + _playerSM.CurrentComboIndex);
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
