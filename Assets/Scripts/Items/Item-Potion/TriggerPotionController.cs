    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TriggerPotionController: MonoBehaviour
    {
        [SerializeField] private Animation Potion = null;

        [SerializeField] float rate;

        [SerializeField] float duration;
        private void OnTriggerEnter2D(Collider2D other)
        {
        if (other != null)
        {
            //other.GetComponent<ISpeedBuff>()?.AbsorbSpeedBuff(rate, duration);
        }
            /*if (other.CompareTag("Player"))
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
                } */
                GameObject potionVFX = Pool.Instance.GetObjectInPool(Enums.EPoolable.PotionVFX);
                potionVFX.SetActive(true);
                potionVFX.transform.position = transform.position;      
                Destroy(gameObject); 
        }
    }
