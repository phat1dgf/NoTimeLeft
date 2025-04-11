using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VehicleController : M_MonoBehaviour
{
    [SerializeField] private VehicleStats _vehicleStats;
    public VehicleStats VehicleStats => _vehicleStats;

    [SerializeField] private VehicleAvatar _vehicleAvatar;
    public VehicleAvatar VehicleAvatar => _vehicleAvatar;   
    protected override void Reset()
    {
        base.Reset();
        this.transform.localPosition = new Vector3(-7,0,0);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadVehicleStats();
        LoadVehicleAvatar();
    }

    private void LoadVehicleAvatar()
    {
        if (this._vehicleAvatar != null) return;
        this._vehicleAvatar = this.GetComponentInChildren<VehicleAvatar>();
    }

    private void LoadVehicleStats()
    {
        if (this._vehicleStats != null) return;
        this._vehicleStats = this.GetComponentInChildren<VehicleStats>();
    }
}
