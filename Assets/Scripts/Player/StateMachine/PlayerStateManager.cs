using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : BaseCharacter, IDamageable, IBuffable
{
    //Bug 0 kích hoạt đc collider attack trong animation attack

    [Header("Number Fields")]
    [SerializeField] float _velo;
    [SerializeField] float _jumpForce;
    [SerializeField] float _groundCheckRadius;
    [SerializeField] float _allowComboDuration;
    [SerializeField] float _delayBackToIdle;

    [Header("GroundCheck Fields")]
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;

    [Header("Throw Position")]
    [SerializeField] Transform _throwPos;

    [Header("Health")]
    [SerializeField] int _maxHealth;

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
    int _currentHealth;
    float initVelo = 0f;
    float durationSB = 0f;
    float entryTimeSB = 0f;
    float _entryTimeDB = 0f;
    float _durationDB = 0f;
    float _dirX;
    bool _groundDetected;
    bool _hasSword = true;
    float _attackEntryTime;
    //Biến đếm giờ bắt đầu perform attack, để check xem còn trong thgian cho phép attack tiếp không
    float _getHitEntryTime;

    public float DirX { get => _dirX; }

    public bool HasSword { get => _hasSword; set => _hasSword = value; }

    public float AttackEntryTime { get => _attackEntryTime; set => _attackEntryTime = value; }

    public float GetHitEntryTime { get => _getHitEntryTime; set => _getHitEntryTime = value; }

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
        initVelo = Velo;
    }

    protected override void Update()
    {
        base.Update();
        HandleFlipSprite();
       //Debug.Log("HP: " + _healthPoint);
        //Debug.Log("Ground: " + _groundDetected);
        HandleSpeedBuffDuration();
        HandleDMGBuffDuration();
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

    public void HandleTakeDamage(float damageTaken)
    {
        _healthPoint -= damageTaken;
        HandleHealthPoint(damageTaken);
        ChangeState((_healthPoint) > 0 ? _getHitState : _dieState);
    }

    private void HandleSpeedBuffDuration()
    {
        if (Time.time - entryTimeSB > durationSB)
            _velo = initVelo;
    }

    //Gọi coroutine ở 2 state atk1, atk2 để trở lại idle sau khi xong animation
    public IEnumerator BackToIdle()
    {
        yield return new WaitForSeconds(_delayBackToIdle);

        ChangeState(_idleState);
    }

    public void HandleBuff(Enums.EBuffs Type, float rate, float duration)
    {
        switch (Type)
        {
            case Enums.EBuffs.Speed:
                durationSB = duration;
                _velo *= rate;
                entryTimeSB = Time.time;
                break;
            case Enums.EBuffs.Health:
                if (_currentHealth < _maxHealth)
                {
                    _currentHealth += (int)rate;
                    if (_currentHealth > _maxHealth)
                    {
                        _currentHealth = _maxHealth;
                        Debug.Log("Health increased");
                    }
                    else
                    {
                        Debug.Log("Max Health");
                    }
                }
                break;
            case Enums.EBuffs.Damage:
                _entryTimeDB = Time.time;
                _durationDB = duration;
                PlayerDmgBuff buffInfo = new(rate, duration);
                EventsManager.Instance.NotifyObservers(Enums.EEvents.PlayerOnReceiveDamageBuff, buffInfo);
                Debug.Log("dmgg");
                break;
        }
    }

    private void HandleDMGBuffDuration()
    {
        if (Time.time - _entryTimeDB >= _durationDB && _entryTimeDB != 0)
        {
            EventsManager.Instance.NotifyObservers(Enums.EEvents.PlayerOnDeDamageBuff, null);
            _entryTimeDB = 0f; //Đảm bảo chỉ thực hiện 1 lần
            Debug.Log("Noti Debuff");
        }
    }

    #region Animation Events

    //Event của animation phóng
    private void HandleThrowSword()
    {
        GameObject sword = Pool.Instance.GetObjectInPool(Enums.EPoolable.Sword);
        sword.SetActive(true);
        sword.transform.position = _throwPos.position;
        EventsManager.Instance.NotifyObservers(Enums.EEvents.SwordOnReceiveDirection, _isFacingRight);
    }

    //Event của Animation Attack 3
    //Đặt ở cuối Frame
    private void AnimEventBackToIdle()
    {
        ChangeState(_idleState);
    }

    #endregion

    #region Check Change States

    public bool CheckIfCanIdle()
    {
        return _dirX == 0 && _groundDetected;
    }

    public bool CheckIfCanAttack(float AtkEntryTime, bool isFirstAtk)
    {
        //Tham số đầu tiên truyền vào entryTime của state Attack đó
        //Để check có đang trong thgian cho phép combo để chuyển sang state Attack + 1

        //First Atk bị block ở đây
        if (isFirstAtk)
            return Input.GetMouseButtonDown(0) && _groundDetected;

        return Input.GetMouseButtonDown(0) && AtkEntryTime != 0
            && Time.time - AtkEntryTime <= _allowComboDuration
            && _groundDetected;
    }

    public bool CheckIfCanThrowSword()
    {
        return Input.GetKeyDown(KeyCode.E) && _hasSword;
    }

    public bool CheckIfCanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && _groundDetected;
    }

    public bool CheckIfCanRun()
    {
        return _dirX != 0 && _groundDetected;
    }

    public bool CheckIfCanFall()
    {
        return _rb.velocity.y < -0.1f && !_groundDetected;
    }

    #endregion
}
