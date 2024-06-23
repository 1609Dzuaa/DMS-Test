﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseCharacter, IDamageable
{
    [Header("Number Fields")]
    [SerializeField] float _velo;
    [SerializeField] float _jumpForce;
    [SerializeField] float _groundCheckRadius;
    [SerializeField] float _delayUpdateAttack;
    [SerializeField] float _allowComboDuration;

    [Header("GroundCheck Fields")]
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;

    [Header("Throw Position")]
    [SerializeField] Transform _throwPos;

    #region States
    PlayerIdleState _idleState = new(); 
    PlayerRunState _runState = new();
    PlayerJumpState _jumpState = new();
    PlayerFallState _fallState = new();
    PlayerAttack1State _attack1State = new();
    PlayerAttack2State _attack2State = new();
    PlayerAttack3State _attack3State = new();
    PlayerGetHitState _getHitState = new();
    PlayerDieState _dieState = new();
    PlayerThrowState _throwState = new();
    #endregion

    float _dirX;
    bool _groundDetected;
    bool _hasSword = true;
    int _currentComboIndex = 0;
    float _attackEntryTime;
    //Biến đếm giờ bắt đầu perform attack, để check xem còn trong thgian cho phép attack tiếp không
    float _getHitEntryTime;

    public float DirX { get => _dirX; }

    public bool HasSword { get => _hasSword; set => _hasSword = value; }

    public int CurrentComboIndex { get => _currentComboIndex; set => _currentComboIndex = value; }

    public float AllowComboDuration { get => _allowComboDuration; }

    public bool GroundDetected { get => _groundDetected; }

    public float AttackEntryTime { get => _attackEntryTime; set => _attackEntryTime = value; }

    public float GetHitEntryTime { get => _getHitEntryTime; set => _getHitEntryTime = value; }

    public float DelayUpdateAttack { get => _delayUpdateAttack; }

    public float Velo { get => _velo; }

    public float JumpForce { get => _jumpForce; }

    public PlayerIdleState IdleState { get => _idleState; set => _idleState = value; }

    public PlayerRunState RunState { get => _runState; set => _runState = value; }

    public PlayerJumpState JumpState { get => _jumpState; set => _jumpState = value; }

    public PlayerFallState FallState { get => _fallState; set => _fallState = value; }

    public PlayerAttack1State Attack1State { get => _attack1State; set => _attack1State = value; }

    public PlayerAttack2State Attack2State { get => _attack2State; set => _attack2State = value; }

    public PlayerAttack3State Attack3State { get => _attack3State; set => _attack3State = value; }

    public PlayerThrowState ThrowState { get => _throwState; set => _throwState = value; }

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
        Debug.Log("HP: " + _healthPoint);
        //Debug.Log("Ground: " + _groundDetected);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, _groundCheckRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Constants.SWORD_TAG_LAYER))
        {
            _hasSword = true;
            _anim.SetBool(Constants.SWORD_PARAM, true);
        }
    }

    //Event của animations attack
    private void BackToIdle()
    {
        ChangeState(_idleState);
    }

    public void HandleTakeDamage(float damageTaken)
    {
        _healthPoint -= damageTaken;
        ChangeState((_healthPoint) > 0 ? _getHitState : _dieState);
    }

    //Event của animation phóng
    private void HandleThrowSword()
    {
        GameObject sword = Pool.Instance.GetObjectInPool(Enums.EPoolable.Sword);
        sword.SetActive(true);
        sword.transform.position = _throwPos.position;
        EventsManager.Instance.NotifyObservers(Enums.EEvents.SwordOnReceiveDirection, _isFacingRight);
    }
}
