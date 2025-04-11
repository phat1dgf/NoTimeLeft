using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleColliding : M_MonoBehaviour
{
    [SerializeField] private Collider2D _colli;
    [SerializeField] private VehicleController _vehicleController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadVehicleController();
    }

    private void LoadVehicleController()
    {
        if (this._vehicleController != null) return;
        this._vehicleController = this.GetComponentInParent<VehicleController>();
    }

    private void LoadCollider()
    {
        if (this._colli != null) return;
        this._colli = this.GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Tag_Obstacle))
        {
            _vehicleController.VehicleStats.GetHit();
        }
    }
}
