using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : BaseObject
{
    [SerializeField] protected float _damageDealt;
    protected bool _activated;
    //Bug here, nếu 0 có th này thì trigger nhiều lần, nếu có thì atk2 của player 0 đc gọi

    protected virtual void OnEnable()
    {
        //Bị gọi 2 lần do trong animation active nó 2 frame
        _activated = false;
        //Debug.Log("En");
    }

    protected virtual void OnDisable()
    {
        _activated = false;
        //Debug.Log("Dis");
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!_activated)
        {
            _activated = true;
            collision.gameObject.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            //Debug.Log("ENter");
        }
    }
}
