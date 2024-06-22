using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerPotion : MonoBehaviour
{
    private int PotionSpeed;
    private int PotionDamage;
    private int PotionBlood;

    private Animation animator;

    private void Start()
    {
        animator = GetComponent<Animation>();
    }

    public void DestroyPotion()
    {
        if (gameObject.CompareTag("Potion Speed"))
        {
            Debug.Log("Potion Speed: " + PotionSpeed);   
        } else if (gameObject.CompareTag("Potion Blood")){
            Debug.Log("Potion Blood: " + PotionBlood);
        } else if (gameObject.CompareTag("Potion Damge"))
        {
            Debug.Log("Potion Damge: " + PotionDamage);
        }
        Destroy(gameObject);
    }
}
