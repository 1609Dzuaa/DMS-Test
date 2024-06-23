using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseObject
{
    [SerializeField] protected float _damageDealt;
    protected bool _activated;

    protected virtual void OnEnable()
    {
        _activated = false;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_activated)
        {
            _activated = true;
            collision.gameObject.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            Debug.Log("ENter");
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (!_activated)
        {
            _activated = true;
            collision.gameObject.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            Debug.Log("Stay");
        }
    }
}
