using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSkullController : MonoBehaviour
{
    [SerializeField] private Animation Skull = null;

    [SerializeField]  GameObject Effect = null ;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Skull != null)
            {
                Skull.Play();
                Destroy(other.gameObject);
            } else
            {
                Debug.Log("Error!");
            }
            Instantiate(Effect, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
}
