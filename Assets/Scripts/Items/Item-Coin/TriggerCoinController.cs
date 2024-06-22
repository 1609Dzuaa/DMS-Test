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
                Coin.Play(); // Ph�t animation c?a ??ng xu
                Destroy(Coin.gameObject); // Ph� h?y GameObject ch?a animation sau khi ho�n th�nh
            }
            else
            {
                Debug.LogWarning("Error!");
            }

            Instantiate(Effect, transform.position, Quaternion.identity, null);

            Destroy(gameObject); // Ph� h?y ??i t??ng ch?a script sau khi x? l� va ch?m
        }
    }
}
