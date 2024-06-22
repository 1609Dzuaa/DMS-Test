using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_GoldCoin : MonoBehaviour
{
    private int GoldcoinID = 0;

    private int SilvercoinID = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Gold Coin"))
        {
            Destroy(other.gameObject);
            GoldcoinID++;
            Debug.Log("Gold Coins: " +  GoldcoinID);
        }

        if(other.CompareTag("Silver Coin"))
        {
            Destroy(other.gameObject);
            SilvercoinID++;
            Debug.Log("Silver Coins: " + SilvercoinID);
        }
    }
}
