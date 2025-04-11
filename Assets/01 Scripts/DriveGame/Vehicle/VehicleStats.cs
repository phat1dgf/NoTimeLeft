using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStats : M_MonoBehaviour,IGetHit
{
    [SerializeField] private int _vehicleHP;
    [SerializeField] private float _immortalTime;
    [SerializeField] private float _immortalTimer;
    [SerializeField] private bool _isImmortal;

    [SerializeField] private VehicleAvatar _vehicleAvatar;
    [SerializeField] private VehicleController _vehicleController;

    protected override void Reset()
    {
        base.Reset();
        _vehicleHP = 3;
        _immortalTime = 1.5f;
        _immortalTimer = _immortalTime;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadVehicleController();
        LoadVehicleAvatar();
        
    }

    private void LoadVehicleController()
    {
        if (this._vehicleController != null) return;
        this._vehicleController = this.GetComponentInParent<VehicleController>();
    }

    private void LoadVehicleAvatar()
    {
        if (this._vehicleAvatar != null) return;
        this._vehicleAvatar = _vehicleController.VehicleAvatar;
    }

    private void Update()
    {
        ImmortalTimeNumbering();
        HPTracking();
    }

    private void HPTracking()
    {
        if(_vehicleHP == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // lose game
    }

    public void GetHit()
    {
        if (!_isImmortal) _vehicleHP -= 1;
        _isImmortal = true;
        _vehicleAvatar.StartFlashing();
    }

    private void ImmortalTimeNumbering()
    {
        if (_isImmortal)
        {
            _immortalTimer -= Time.deltaTime;
            if (_immortalTimer <= 0f)
            {
                _isImmortal = false;
                _immortalTimer = _immortalTime;
                _vehicleAvatar.StopFlashing();
            }
        }
    }    
    
}
