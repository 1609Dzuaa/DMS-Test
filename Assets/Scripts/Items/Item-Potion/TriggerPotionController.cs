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
           
                ManagerPotion character = other.gameObject.GetComponent<ManagerPotion>();
                if ( character != null )
                {
                    if(gameObject.CompareTag("Potion Blood"))
                    {
                        character.IncreaseHealth(20);
                    } else if(gameObject.CompareTag("Potion Damage")) 
                    {
                        character.IncreaseDamage(5);        
                    } else if(gameObject.CompareTag("Potion Speed"))
                    {
                        character.IncreaseSpeed(5);
                    }
                }
            
                Instantiate( Effect, transform.position, Quaternion.identity ,null );
                Destroy(gameObject);
            }
        }
    }
