using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : M_MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigid;
    [SerializeField] protected float _speed;

    protected override void Reset()
    {
        base.Reset();
        this._rigid.gravityScale = 0;
        this._rigid.freezeRotation = true;
        this._speed = 5;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponentInParent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        Moving();
    }
    protected virtual void OnEnable()
    {
        Moving();
    }
    protected virtual void Moving()
    {
        this._rigid.velocity = new Vector2(-_speed,0);
    }
}
