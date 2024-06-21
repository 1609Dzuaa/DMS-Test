using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseCharacter
{
    private PlayerIdleState _idleState = new(); 

    protected override void GetRefComponents()
    {
        base.GetRefComponents();
    }

    protected override void SetUpProperties()
    {
        base.SetUpProperties();
        ChangeState(_idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
