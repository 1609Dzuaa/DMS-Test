using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : BaseBuff
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            other.GetComponent<IBuffable>()?.HandleBuff(type, rate, duration);
        }
        GameObject potionVFX = Pool.Instance.GetObjectInPool(Enums.EPoolable.PotionVFX);
        potionVFX.SetActive(true);
        potionVFX.transform.position = transform.position;
        Destroy(gameObject);
    }
}
