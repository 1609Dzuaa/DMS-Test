using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int GoldcoinID = 0;
    private int SilvercoinID = 0;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DestroyCoin()
    {
        if(gameObject.CompareTag("Gold Coin"))
        {
            GoldcoinID++;
            Debug.Log("Gold Coin: " + GoldcoinID);
        }
        else if (gameObject.CompareTag("Silver Coin"))
        {
            SilvercoinID++;
            Debug.Log("Silver Coin: " + SilvercoinID);
        }

        Destroy(gameObject);
    }
}
