using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : M_MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private float _speed;

    protected override void Reset()
    {
        base.Reset();
        this._rigid.gravityScale = 0;
        this._rigid.freezeRotation = true;
        this._speed = 1;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody();
    }

    private void LoadRigidbody()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponentInParent<Rigidbody2D>();
    }
    private void Start()
    {
        Moving();
    }
    private void OnEnable()
    {
        Moving();
    }
    private void Moving()
    {
        this._rigid.velocity = new Vector2(-_speed,0);
    }
}
