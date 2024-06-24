using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSkullController : MonoBehaviour
{
    [SerializeField] private Animation Skull = null;

    [SerializeField] GameObject Effect = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Skull != null)
            {
                Skull.Play();
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Error!");
            }
            GameObject skullVFX = Pool.Instance.GetObjectInPool(Enums.EPoolable.SkullVFX);
            skullVFX.SetActive(true);
            skullVFX.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
