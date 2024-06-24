using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarStateManager : EnemyStateManger
{
    [SerializeField] float _attackVelo;

    StarAttackState _starAttackState = new();

    public float AttackVelo { get => _attackVelo; }

    protected override void SetUpProperties()
    {
        base.SetUpProperties();
        _attackState = _starAttackState;
    }
}
