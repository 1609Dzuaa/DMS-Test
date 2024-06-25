using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyStateManger : BaseCharacter, IDamageable
{
    [SerializeField] protected Transform _playerCheck;
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected Transform _wallCheck;
    [SerializeField] protected EnemySO _enemySO;
    [SerializeField] protected Transform _playerRef;

    #region States
    protected EnemyIdleState _idleState = new();
    protected EnemyPatrolState _patrolState = new();
    protected EnemyChaseState _chaseState = new();
    protected EnemyAttackState _attackState = new();
    protected EnemyGetHitState _hitState = new();
    protected EnemyDieState _dieState = new();
    #endregion

    protected RaycastHit2D _playerHit;
    protected bool _playerDetected;
    protected bool _groundDetected;
    protected bool _wallDetected;
    protected float _entryTime;
    //protected bool _isSwordStuckInside;

    public EnemyIdleState IdleState { get => _idleState; set=>_idleState = value; }

    public EnemyPatrolState PatrolState { get => _patrolState; set => _patrolState = value; }

    public EnemyChaseState ChaseState { get => _chaseState; set => _chaseState = value; }

    public EnemyAttackState AttackState { get => _attackState; set => _attackState = value; }

    public EnemyGetHitState GetHitState { get => _hitState; set => _hitState = value; }

    public EnemyDieState DieState { get => _dieState; set => _dieState = value; }

    public EnemySO GetEnemySO { get => _enemySO; }

    public Transform PlayerRef { get => _playerRef; }

    public float EntryTime { get => _entryTime; set => _entryTime = value; }

    public bool PlayerDetected { get => _playerDetected; }

    public bool GroundDetected { get => _groundDetected; }

    public bool WallDetected { get => _wallDetected; }

    protected override void SetUpProperties()
    {
        base.SetUpProperties();
        ChangeState(_idleState);
    }

    protected override void Update()
    {
        base.Update();
        DrawRayDetectGround();
        DrawRayDetectWall();
        Debug.Log("HP: " + _healthPoint);
    }

    protected void DrawRayDetectWall()
    {
        if (!_wallDetected)
        {
            if (!_isFacingRight)
                Debug.DrawRay(_wallCheck.position, Vector2.left * _enemySO.GWCheckDist, Color.green);
            else
                Debug.DrawRay(_wallCheck.position, Vector2.right * _enemySO.GWCheckDist, Color.green);
        }
        else
        {
            if (!_isFacingRight)
                Debug.DrawRay(_wallCheck.position, Vector2.left * _enemySO.GWCheckDist, Color.red);
            else
                Debug.DrawRay(_wallCheck.position, Vector2.right * _enemySO.GWCheckDist, Color.red);
        }
    }

    protected void DrawRayDetectGround()
    {
        if (!_groundDetected)
            Debug.DrawRay(_groundCheck.position, Vector2.down * _enemySO.GWCheckDist, Color.green);
        else
            Debug.DrawRay(_groundCheck.position, Vector2.down * _enemySO.GWCheckDist, Color.red);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        PlayerCheck();
        GroundCheck();
        WallCheck();
        //Debug.Log("Rb Sleep?: " + _rb.IsSleeping());
    }

    protected virtual void PlayerCheck()
    {
        if (!_playerCheck) return;

        _playerHit = Physics2D.Raycast(_playerCheck.position, (_isFacingRight) ? Vector2.right : Vector2.left, _enemySO.PlayerCheckDist, _enemySO.PlayerLayer);
        if (_playerHit)
        {
            _playerDetected = _playerHit.collider.CompareTag(Constants.PLAYER_TAG_LAYER);
            //Debug.Log((_playerDetected) ? "Founded" : "Not Found");
        }
    }

    protected virtual void GroundCheck()
    {
        _groundDetected = Physics2D.Raycast(_groundCheck.position, Vector2.down, _enemySO.GWCheckDist, _enemySO.GWLayer);
    }

    protected virtual void WallCheck()
    {
        _wallDetected = Physics2D.Raycast(_wallCheck.position, (_isFacingRight) ? Vector2.right : Vector2.left, _enemySO.GWCheckDist, _enemySO.GWLayer);
    }

    public void HandleTakeDamage(float damageTaken)
    {
        HandleHealthPoint(damageTaken);
        ChangeState((_healthPoint) > 0 ? _hitState : _dieState);
        Debug.Log("Taken");
    }

    //Event của animation attack đặt ở cuối frame
    private void BackToIdle()
    {
        ChangeState(_idleState);
    }

    //Đặt ở animation Die
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
