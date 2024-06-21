using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManger : BaseCharacter
{
    [SerializeField] Transform _playerCheck;
    [SerializeField] protected EnemySO _enemySO;

    protected RaycastHit2D _playerHit;
    protected bool _playerDetected;

    public bool PlayerDetected { get => _playerDetected; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        PlayerCheck();
    }

    protected virtual void PlayerCheck()
    {
        _playerHit = Physics2D.Raycast(_playerCheck.position, (_isFacingRight) ? Vector2.right : Vector2.left, _enemySO.PlayerCheckDist, _enemySO.PlayerLayer);
        if (_playerHit)
        {
            _playerDetected = _playerHit.collider.CompareTag(Constants.PLAYER_TAG);
            Debug.Log((_playerDetected) ? "Founded" : "Not Found");
        }
    }
}
