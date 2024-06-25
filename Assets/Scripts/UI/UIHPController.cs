using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHPController : MonoBehaviour
{
    [SerializeField] Transform _targetPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = _targetPos.position;
    }
}
