using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static Enums;

public class SwordController : WeaponController
{
    [SerializeField] float _swordVelo;
    [SerializeField] float _newSizeX;
    [SerializeField, Tooltip("Thêm/Bớt đoạn này khi ghim vào quái")] float _offsetCollide;
    BoxCollider2D _collider;
    float _initSizeX;
    bool _isStuck;

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
        if(collision.collider.CompareTag(Constants.GROUND_TAG_LAYER))
        {
            //Dính địa hình
            HandleWhenSwordCollide((int)ESwordState.Embedded, Constants.WEAPON_LAYER, _newSizeX, false, false, null);
        }
        else if(collision.collider.CompareTag(Constants.PLAYER_TAG_LAYER))
        {
            //Chạm Player => Thu kiếm về
            HandleWhenSwordCollide((int)ESwordState.Idle, Constants.PLAYER_TAG_LAYER, _initSizeX, false, false, null);
            gameObject.SetActive(false);
        }
        else if(collision.collider.CompareTag(Constants.ENEMY_TAG_LAYER))
        {
            //Ghim kiếm vào quái, chỉnh speed, chỉnh offset
            collision.collider.GetComponent<IDamageable>()?.HandleTakeDamage(_damageDealt);
            transform.position += new Vector3((_isFacingRight) ? _offsetCollide : -_offsetCollide, 0f, 0f);
            _rb.velocity = Vector2.zero;
            Transform pTransf = collision.collider.transform;
            HandleWhenSwordCollide((int)ESwordState.Embedded, Constants.ENEMY_TAG_LAYER, _newSizeX, true, true, pTransf);
        }
    }

    private void HandleWhenSwordCollide(int AnimParam, string NewLayer, float NewSizeX, bool IsKine, bool IsStuck, Transform ParentTransform)
    {
        _anim.SetInteger(Constants.STATE_PARAM, AnimParam);
        gameObject.layer = LayerMask.NameToLayer(NewLayer);
        transform.parent = ParentTransform;
        _collider.size = new Vector2(NewSizeX, _collider.size.y);
        _rb.isKinematic = IsKine;
        _isStuck = IsStuck;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        //base.OnTriggerStay2D(collision);
    }

    private void FixedUpdate()
    {
        if (_isStuck) return;

        _rb.velocity = new((_isFacingRight) ? _swordVelo : -_swordVelo, 0f);
        //Debug.Log("kine: " + _rb.isKinematic);
    }

    private void ReceiveDirection(object obj)
    {
        if (_isFacingRight != (bool)obj)
            FlipSprite();
        _anim.SetInteger(Constants.STATE_PARAM, (int)ESwordState.Spin);
    }
}
