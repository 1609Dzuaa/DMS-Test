using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy : EnemyStateManger
{
    [SerializeField] Transform _groundCheck;
    [SerializeField] Transform _wallCheck;
    [SerializeField] MoveableEnemySO _mEnemySO;

    protected bool _groundDetected;
    protected bool _wallDetected;

    public bool GroundDetected { get => _groundDetected; }

    public bool WallDetected { get => _wallDetected; }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        GroundCheck();
        WallCheck();
    }

    protected virtual void GroundCheck()
    {
        _groundDetected = Physics2D.Raycast(_groundCheck.position, Vector2.down, _mEnemySO.GWCheckDist, _mEnemySO.GWLayer);
    }

    protected virtual void WallCheck()
    {
        _wallDetected = Physics2D.Raycast(_wallCheck.position, (_isFacingRight) ? Vector2.right : Vector2.left, _mEnemySO.GWCheckDist, _mEnemySO.GWLayer);
    }
}
