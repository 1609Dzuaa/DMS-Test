using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPotionController: MonoBehaviour
{
    [SerializeField] private Animation Potion = null;

    [SerializeField] GameObject Effect = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if( Potion != null )
            {
                Potion.Play();
                Destroy(Potion.gameObject);
            } else
            {
                Debug.Log("Error!");
            }
            Instantiate( Effect, transform.position, Quaternion.identity ,null );
            Destroy(gameObject);
        }
    }
}
