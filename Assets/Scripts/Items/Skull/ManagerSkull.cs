using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ManagerSkull : MonoBehaviour
{
    private int SkullID;

    private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator = other.GetComponent<Animator>();
    }
    
    private void DestroySkull()
    {
        if (gameObject.CompareTag("Skull")) 
        {   
            Debug.Log("Skull: " + SkullID);
        }

        Destroy(gameObject);
    }
}
