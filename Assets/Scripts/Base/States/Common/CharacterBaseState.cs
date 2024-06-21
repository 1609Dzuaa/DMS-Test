using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseState
{
    protected BaseCharacter _baseCharacter;

    public virtual void EnterState(BaseCharacter baseCharacter)
    {
        _baseCharacter = baseCharacter;
    }

    public virtual void ExitState() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}
