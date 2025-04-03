using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMoving : M_MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private float _speed;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody();
    }

    private void LoadRigidbody()
    {
        if (_rigid != null) return;
        this._rigid = this.GetComponentInParent<Rigidbody2D>();
    }
    protected override void Reset()
    {
        base.Reset();
        this._rigid.freezeRotation = true;
        this._rigid.gravityScale = 0f;
        this._speed = 5;
    }
    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (InputManager.Instance.IsMoving)
            this._movement.x = Input.GetAxisRaw("Horizontal");
        else
            this._movement = Vector2.zero;

        this._rigid.velocity = this._movement * this._speed;
    }
}
