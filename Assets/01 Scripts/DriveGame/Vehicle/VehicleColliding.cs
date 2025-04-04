using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleColliding : M_MonoBehaviour, IGetHit
{
    [SerializeField] private Collider2D _colli;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }
    private void LoadCollider()
    {
        if (this._colli != null) return;
        this._colli = this.GetComponent<Collider2D>();
    }
    public void GetHit()
    {
        throw new System.NotImplementedException();
    }
}
