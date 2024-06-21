using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : CharacterBaseState
{
    protected PlayerStateManager _playerSM;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        _playerSM = (PlayerStateManager)baseCharacter;
    }
}
