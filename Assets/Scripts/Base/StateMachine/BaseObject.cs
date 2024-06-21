using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    protected Animator _anim;

    public Animator Anim { get => _anim; set => _anim = value; }

    protected virtual void Awake()
    {
        GetRefComponents();
    }

    protected virtual void GetRefComponents()
    {
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected virtual void Start() { }

    // Update is called once per frame
    protected virtual void Update() { }
}
