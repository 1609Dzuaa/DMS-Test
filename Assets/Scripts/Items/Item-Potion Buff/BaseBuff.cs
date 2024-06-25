using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class BaseBuff : MonoBehaviour
{
    [SerializeField] protected EBuffs type;

    [SerializeField] protected float rate;

    [SerializeField] protected float duration;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            other.GetComponent<IBuffable>()?.HandleBuff(type, rate, duration);
            HandleSpawnVFX();
        }
    }

    protected void HandleSpawnVFX(/*EPoolable vfxName | Dùng khi muốn spawn vfx khác*/)
    {
        GameObject potionVFX = Pool.Instance.GetObjectInPool(EPoolable.PotionVFX);
        potionVFX.SetActive(true);
        potionVFX.transform.position = transform.position;
        Destroy(gameObject);
    }
}
