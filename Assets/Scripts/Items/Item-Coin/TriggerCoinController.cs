using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoinController : MonoBehaviour
{
    [SerializeField] private Animation Coin = null;

    [SerializeField] GameObject Effect = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Coin != null)
            {
                Coin.Play(); // Phát animation c?a ??ng xu
                Destroy(Coin.gameObject); // Phá h?y GameObject ch?a animation sau khi hoàn thành
            }
            else
            {
                Debug.LogWarning("Error!");
            }

            Instantiate(Effect, transform.position, Quaternion.identity, null);

            Destroy(gameObject); // Phá h?y ??i t??ng ch?a script sau khi x? lý va ch?m
        }
    }
}
