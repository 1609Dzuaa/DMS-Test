using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : BaseObject
{
    #region !PUBLIC FIELDS
    
    protected CharacterBaseState _state;
    protected Rigidbody2D _rb;
    [SerializeField] protected bool _isFacingRight;

    #endregion

    #region PUBLIC FIELDS

    public Rigidbody2D Rb2D { get => _rb; set => _rb = value; }

    public bool IsFacingRight { get => _isFacingRight; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void GetRefComponents()
    {
        base.GetRefComponents();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        SetUpProperties();
    }

    protected virtual void SetUpProperties()
    {

    }

    public virtual void ChangeState(CharacterBaseState state)
    {
        _state?.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    public void FlipSprite()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
        //Debug.Log("Flip");
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
