using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerPotion : MonoBehaviour
{
    private int PotionSpeed = 20;
    private int PotionDamage = 10;
    private int PotionBlood = 3;

    private Animation animator;

    private void Start()
    {
        animator = GetComponent<Animation>();
    }

    public void IncreaseHealth(int health)
    {
        PotionBlood += health;
        Debug.Log("IncreaseHealth:" + PotionBlood);
    }

    public void IncreaseDamage(int damge)
    {
        PotionDamage += damge;
        Debug.Log("IncreaseDamage: " + PotionDamage);
    }

    public void IncreaseSpeed(int speed)
    {
        PotionSpeed += speed;
        Debug.Log("IncreaseSpeed: " + PotionSpeed);
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
