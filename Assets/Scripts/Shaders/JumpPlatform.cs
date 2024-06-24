using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public float jumpForce = 10f; // L?c ??y l�n

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // ??t t?c ?? y c?a player th�nh 0 ?? ??m b?o r?ng l?c ??y kh�ng b? ?nh h??ng b?i l?c kh�c
                rb.velocity = new Vector2(rb.velocity.x, 0f);

                // Th�m l?c ??y l�n cho player
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
