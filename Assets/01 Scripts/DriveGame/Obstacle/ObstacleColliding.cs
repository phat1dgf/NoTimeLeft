using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColliding : M_MonoBehaviour
{
    [SerializeField] protected Collider2D _colli;
    protected override void Reset()
    {
        base.Reset();
        this._colli.isTrigger = true;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this._colli != null) return;
        this._colli = this.GetComponent<Collider2D>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Tag_Player))
        {
            IGetHit vehicle = collision.GetComponent<IGetHit>();
            if (vehicle != null)
            {
                vehicle.GetHit();
            }
        }
    }
}
