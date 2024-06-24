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
                Destroy(Coin.gameObject); // Ph� h?y gameobject c?a ??ng xu
            }
            else
            {
                Debug.LogWarning("Error!");
            }
            GameObject coinVFX = Pool.Instance.GetObjectInPool(Enums.EPoolable.CoinVFX);
            coinVFX.SetActive(true);
            coinVFX.transform.position = transform.position;
            Destroy(gameObject); // Ph� h?y ??ng x? l� va ch?m
        }
    }   
}
