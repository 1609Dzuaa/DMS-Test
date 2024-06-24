using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerBaseState
{
    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Attack3);
        _playerSM.Attack2State.EntryTime = 0;
        _playerSM.CurrentComboIndex = 0;
        SoundsManager.Instance.PlaySfx(Enums.ESounds.Attack3Sfx);
        _playerSM.Attack2State.EntryTime = 0;
        Debug.Log("Player Atk3");
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