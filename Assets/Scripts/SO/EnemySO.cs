using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    [Header("Check & Distance Related")]
    [SerializeField] float _playerCheckDist;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] float _attackableRange;

    [Header("Velo, Force Related")]
    [SerializeField] float _patrolVelo;
    [SerializeField] float _chaseVelo;

    [Header("Time Related")]
    [SerializeField] float _patrolTime;
    [SerializeField] float _restTime;

    [SerializeField] float _gwCheckDist;
    [SerializeField] LayerMask _gwLayer; //gw : Ground || Wall

    public float PatrolVelo { get => _patrolVelo; }

    public float ChaseVelo { get => _chaseVelo; }

    public float PatrolTime { get => _patrolTime; }

    public float RestTime { get => _restTime; }

    public float GWCheckDist { get => _gwCheckDist; }

    public LayerMask GWLayer { get => _gwLayer; }

    public float PlayerCheckDist { get => _playerCheckDist; }

    public LayerMask PlayerLayer { get => _playerLayer; }

    public float AttackableRange { get => _attackableRange; }
}
