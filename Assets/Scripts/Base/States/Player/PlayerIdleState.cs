using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : CharacterBaseState
{
    private PlayerStateManager _playerSM;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        _playerSM = (PlayerStateManager)baseCharacter;
        Debug.Log("Player Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
