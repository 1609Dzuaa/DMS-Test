using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [Header("Is Sprite Left Or Right")]
    [SerializeField] protected bool _isFacingRight;

    protected Animator _anim;
    protected Rigidbody2D _rb;

    public bool IsFacingRight { get => _isFacingRight; }

    public Animator Anim { get => _anim; set => _anim = value; }

    public Rigidbody2D Rb2D { get => _rb; set => _rb = value; }

    protected virtual void Awake()
    {
        GetRefComponents();
    }

    protected virtual void GetRefComponents()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void SetUpProperties()
    {

    }

    // Start is called before the first frame update
    protected virtual void Start() { SetUpProperties(); }

    // Update is called once per frame
    protected virtual void Update() { }

    public void FlipSprite()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
        //Debug.Log("Flip");
    }
}
