using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaseCharacter : BaseObject
{
    #region !PUBLIC FIELDS
    
    protected CharacterBaseState _state;
    protected float _baseHP;

    [Header("HP")]
    [SerializeField] protected float _healthPoint;

    [Header("HP UI Ref")]
    [SerializeField] protected Image _hpFill; //Thanh máu để fill
    [SerializeField] protected GameObject _hpBar; //Gobj chứa thanh máu
    [SerializeField] protected float _fillSpeed;

    [Header("Character's Weapon")]
    [SerializeField] protected WeaponController _weaponCtrl;

    #endregion

    #region PUBLIC FIELDS

    public GameObject HPBar { get => _hpBar; set => _hpBar = value; }

    #endregion

    public virtual void ChangeState(CharacterBaseState state)
    {
        _state?.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    protected override void SetUpProperties()
    {
        _baseHP = _healthPoint;
    }

    protected override void Update()
    {
        _state?.Update();
    }

    protected virtual void FixedUpdate()
    {
        _state?.FixedUpdate();
    }

    protected void HandleHealthPoint(float damageTaken, bool isIncrease)
    {
        _healthPoint += isIncrease ? damageTaken : -damageTaken;
        Mathf.Clamp(_healthPoint, 0f, _baseHP);
        _hpFill.DOFillAmount(_healthPoint / _baseHP, _fillSpeed);
    }

    #region Animation Events

    //Event của animation attack wakeup rb khi attack tránh TH:
    //Player và quái đứng yên nhưng kh bắt đc trigger collision
    protected void WakeUpRigidbody()
    {
        _rb.WakeUp();
    }

    //Tắt ở frame attack collider bị disable để 0 có collision, tránh OnTrigger bị gọi lần nữa
    protected void RigidbodySleep()
    {
        _rb.Sleep();
    }

    //Đặt ở frame cuối của attack animation để reset lại biến bool
    //Mục đích biến bool đó là để chỉ gọi hàm nhận dmg trong trigger của vũ khí đó 1 lần duy nhất
    protected void ResetActivated()
    {
        _weaponCtrl.ResetActivated();
    }

    #endregion
}
