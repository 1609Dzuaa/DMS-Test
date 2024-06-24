using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1State : PlayerBaseState
{
    private float _entryTime = 0;

    public float EntryTime { get => _entryTime; set => _entryTime = value; }

    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Attack1);
        _playerSM.AttackEntryTime = Time.time;
<<<<<<< Updated upstream
        _playerSM.StartCoroutine(_playerSM.BackToIdle());
        _entryTime = Time.time;
=======
        _playerSM.CurrentComboIndex = 1;
        SoundsManager.Instance.PlaySfx(Enums.ESounds.Attack1Sfx);
>>>>>>> Stashed changes
        Debug.Log("Player Atk1");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update() { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}