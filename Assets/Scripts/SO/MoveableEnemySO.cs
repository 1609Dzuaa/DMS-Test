using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MoveableEnemySO", order = 2)]
public class MoveableEnemySO : ScriptableObject
{
    [SerializeField] float _gwCheckDist;
    [SerializeField] LayerMask _gwLayer; //gw : Ground || Wall

    public float GWCheckDist { get => _gwCheckDist; }

    public LayerMask GWLayer { get => _gwLayer; }
}
