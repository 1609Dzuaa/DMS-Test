using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseObject
{
    [SerializeField] protected float _damageDealt;
    protected bool _activated;

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }

    //Animation event
    public void ResetActivated()
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
            //Debug.Log("ENter");
        }
    }
}
