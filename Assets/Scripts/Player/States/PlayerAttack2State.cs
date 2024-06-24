using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState
{
    private float _entryTime = 0;

    public float EntryTime { get => _entryTime; set => _entryTime = value; }

    public override void EnterState(BaseCharacter baseCharacter)
    {
        base.EnterState(baseCharacter);
        _playerSM.Anim.SetInteger(Constants.STATE_PARAM, (int)Enums.EPlayerState.Attack2);
        _playerSM.AttackEntryTime = Time.time;
        _playerSM.Attack1State.EntryTime = 0;
        _entryTime = Time.time;
        _playerSM.StartCoroutine(_playerSM.BackToIdle());
        SoundsManager.Instance.PlaySfx(Enums.ESounds.Attack2Sfx);
        _playerSM.Attack1State.EntryTime = 0;
        _entryTime = Time.time;
        _playerSM.StartCoroutine(_playerSM.BackToIdle());
        Debug.Log("Player Atk2");
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