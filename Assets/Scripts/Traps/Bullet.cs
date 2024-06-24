using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStateManager playerStateManager = collision.gameObject.GetComponent<PlayerStateManager>();
            if (playerStateManager != null)
            {
                playerStateManager.HandleTakeDamage(damage);
            }
        }

        // H?y ??i t??ng ??n sau khi va ch?m
        Destroy(gameObject);
    }
}
