using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] float _damageDealt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
    }
}
