using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Rb2D.velocity = Vector2.zero;
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
