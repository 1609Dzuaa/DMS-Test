using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseCharacter
{
    [SerializeField] float _velo;
    [SerializeField] float _jumpForce;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundCheckRadius;

    PlayerIdleState _idleState = new(); 
    PlayerRunState _runState = new();
    PlayerJumpState _jumpState = new();
    PlayerFallState _fallState = new();
    PlayerAttack1State _attack1State = new();
    PlayerAttack2State _attack2State = new();
    PlayerAttack3State _attack3State = new();
    PlayerGetHitState _getHitState = new();
    PlayerDieState _dieState = new();

    float _dirX;
    bool _groundDetected;

    public float DirX { get => _dirX; }

    public bool GroundDetected { get => _groundDetected; }

    public float Velo { get => _velo; }

    public float JumpForce { get => _jumpForce; }

    public PlayerIdleState IdleState { get => _idleState; set => _idleState = value; }

    public PlayerRunState RunState { get => _runState; set => _runState = value; }

    public PlayerJumpState JumpState { get => _jumpState; set => _jumpState = value; }

    public PlayerFallState FallState { get => _fallState; set => _fallState = value; }

    public PlayerAttack1State Attack1State { get => _attack1State; set => _attack1State = value; }

    public PlayerAttack2State Attack2State { get => _attack2State; set => _attack2State = value; }

    public PlayerAttack3State PlayerAttack3State { get => _attack3State; set => _attack3State = value; }

    public PlayerGetHitState GetHitState { get => _getHitState; set => _getHitState = value; }

    public PlayerDieState PlayerDieState { get => _dieState; set => _dieState = value; }

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
        HandleFlipSprite();
    }

    private void HandleInput()
    {
        _dirX = Input.GetAxisRaw(Constants.HORIZONTAL_AXIS);
    }

    private void HandleFlipSprite()
    {
        HandleInput();

        if (_isFacingRight && _dirX < 0) FlipSprite();
        else if (!_isFacingRight && _dirX > 0) FlipSprite();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        GroundCheck();
    }

    private void GroundCheck()
    {
        if (!_groundCheck) return;

        _groundDetected = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
