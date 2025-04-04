using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMoving : M_MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private float _speedHorizontal, _speedForward, _speedBack, speedX;
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
        this._speedHorizontal = 5;
        this._speedBack = 6.5f;
        this._speedForward = 3.5f;
    }
    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (InputManager.Instance.IsMoving)
        { 
            this._movement.x = Input.GetAxisRaw("Horizontal");
            this._movement.y = Input.GetAxisRaw("Vertical");
        }
        else
            this._movement = Vector2.zero;

        speedX = (this._movement.x > 0) ? this._speedForward : this._speedBack;

        this._rigid.velocity = new Vector2(
            this._movement.x * speedX,
            this._movement.y * this._speedHorizontal
        );
    }
}
