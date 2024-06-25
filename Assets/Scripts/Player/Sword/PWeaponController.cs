using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerDmgBuff
{
    public float _rate;
    public float _duration;

    public PlayerDmgBuff(float rate, float duration)
    {
        _rate = rate;
        _duration = duration;
    }
}

public class PWeaponController : WeaponController
{
    float _rateReceived; 

    protected override void Awake()
    {
        base.Awake();
        SetUpProperties();
        Debug.Log("Sub");
    }

    protected override void Start()
    {
        //Kh gọi base tránh bị gọi setup 2 lần
    }

    protected override void SetUpProperties()
    {
        EventsManager.Instance.SubcribeToAnEvent(Enums.EEvents.PlayerOnReceiveDamageBuff, ReceiveBuff);
        EventsManager.Instance.SubcribeToAnEvent(Enums.EEvents.PlayerOnDeDamageBuff, DeDamageBuff);
    }

    protected void OnDestroy()
    {
        EventsManager.Instance.UnSubcribeToAnEvent(Enums.EEvents.PlayerOnReceiveDamageBuff, ReceiveBuff);
        EventsManager.Instance.UnSubcribeToAnEvent(Enums.EEvents.PlayerOnDeDamageBuff, DeDamageBuff);
    }

    protected void ReceiveBuff(object obj)
    {
        PlayerDmgBuff buff = (PlayerDmgBuff)obj;
        _damageDealt *= buff._rate;
        _rateReceived = buff._rate;
        Debug.Log("rate, dmgDealt:" + _rateReceived + ", " + _damageDealt);
    }

    protected void DeDamageBuff(object obj)
    {
        _damageDealt /= _rateReceived;
        Debug.Log("DeDMG: " + _damageDealt);
    }
}
