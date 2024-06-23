using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class SwordController : WeaponController
{
    [SerializeField] float _swordVelo;
    [SerializeField] float _newSizeX;
    BoxCollider2D _collider;
    float _initSizeX;

    protected override void SetUpProperties()
    {
        _initSizeX = _collider.size.x;
    }

    protected override void GetRefComponents()
    {
        base.GetRefComponents();
        _collider = GetComponent<BoxCollider2D>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventsManager.Instance.SubcribeToAnEvent(EEvents.SwordOnReceiveDirection, ReceiveDirection);
        _anim.SetInteger(Constants.STATE_PARAM, (int)ESwordState.Idle);
    }

    private void OnDisable()
    {
        EventsManager.Instance.UnSubcribeToAnEvent(EEvents.SwordOnReceiveDirection, ReceiveDirection);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag(Constants.GROUND_TAG))
        {
            _anim.SetInteger(Constants.STATE_PARAM, (int)ESwordState.Embedded);
            _collider.size = new Vector2(_newSizeX, _collider.size.y);
            _collider.isTrigger = true;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //base.OnTriggerEnter2D(collision);
        if (collision.CompareTag(Constants.PLAYER_TAG))
        {
            _anim.SetInteger(Constants.STATE_PARAM, (int)ESwordState.Idle);
            _collider.size = new Vector2(_initSizeX, _collider.size.y);
            _collider.isTrigger = false;
            gameObject.SetActive(false);
            //Coi lại đoạn trigger
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        //base.OnTriggerStay2D(collision);
    }

    private void FixedUpdate()
    {
        if (_collider.isTrigger) return;

        _rb.velocity = new((_isFacingRight) ? _swordVelo : -_swordVelo, 0f);
    }

    private void ReceiveDirection(object obj)
    {
        if (_isFacingRight != (bool)obj)
            FlipSprite();
        _anim.SetInteger(Constants.STATE_PARAM, (int)ESwordState.Spin);
    }
}
