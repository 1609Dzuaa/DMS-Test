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

    #endregion

    #region PUBLIC FIELDS

    public float HealthPoint { get => _healthPoint; set => _healthPoint = value; }

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
        HanleHPBarRotation();
    }

    protected virtual void FixedUpdate()
    {
        _state?.FixedUpdate();
    }

    protected void HanleHPBarRotation()
    {
        //Cố định 0 cho thanh hp rotate khi parent object rotate
        if (_hpBar != null)
            if (_hpBar.transform.eulerAngles.y > 0)
                _hpBar.transform.eulerAngles = new(_hpBar.transform.eulerAngles.x, 0f, _hpBar.transform.eulerAngles.z);
    }

    protected void HandleHealthPoint(float damageTaken)
    {
        _healthPoint -= damageTaken;
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

    #endregion
}
