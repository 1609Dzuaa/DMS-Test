using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public float jumpForce = 10f; // L?c ??y lên

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // ??t t?c ?? y c?a player thành 0 ?? ??m b?o r?ng l?c ??y không b? ?nh h??ng b?i l?c khác
                rb.velocity = new Vector2(rb.velocity.x, 0f);

                // Thêm l?c ??y lên cho player
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
