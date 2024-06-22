using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : BaseObject
{
    #region !PUBLIC FIELDS
    
    protected CharacterBaseState _state;

    [Header("HP")]
    [SerializeField] protected float _healthPoint; 

    #endregion

    #region PUBLIC FIELDS

    public float HealthPoint { get => _healthPoint; set => _healthPoint = value; }

    #endregion

    public virtual void ChangeState(CharacterBaseState state)
    {
        _state?.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    protected override void Update()
    {
        _state?.Update();
    }

    protected virtual void FixedUpdate()
    {
        _state?.FixedUpdate();
    }
}
