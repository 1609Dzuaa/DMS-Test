using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuff : MonoBehaviour
{
    [SerializeField] protected Enums.EBuffs type;

    [SerializeField] protected float rate;

    [SerializeField] protected float duration;

}
