using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    [SerializeField] float _playerCheckDist;
    [SerializeField] LayerMask _playerLayer;

    public float PlayerCheckDist { get => _playerCheckDist; }

    public LayerMask PlayerLayer { get => _playerLayer; }
}
