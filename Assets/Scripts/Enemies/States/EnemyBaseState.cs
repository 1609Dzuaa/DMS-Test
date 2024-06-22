using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : CharacterBaseState
{
    protected EnemyStateManger _enemySM;

    public override void EnterState(BaseCharacter baseCharacter)
    {
        _enemySM = (EnemyStateManger)baseCharacter;
    }
}
