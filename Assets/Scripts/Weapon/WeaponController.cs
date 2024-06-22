using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] float _damageDealt;
    bool _activated;

    private void OnEnable()
    {
        _activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
        {
            _activated = true;
            collision.gameObject.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            Debug.Log("ENter");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_activated)
        {
            _activated = true;
            collision.gameObject.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            Debug.Log("Stay");
        }
    }
}
