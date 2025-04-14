using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleHealthUI : M_MonoBehaviour
{
    [SerializeField] private GameObject _vehicleHealthUI;
    [SerializeField] private GameObject _heartIcon;
    [SerializeField] private int _HP;
    private int _lastHP = -1;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadVehicleHealthUI();
    }

    private void LoadVehicleHealthUI()
    {
        if (_vehicleHealthUI != null) return;
        this._vehicleHealthUI = this.gameObject;
    }

    private void Update()
    {
        _HP = DriveGameManager.Instance.Vehicle.VehicleStats.VehicleHP;
        if (_HP == _lastHP) return;
        UpdateHearts();
        _lastHP = _HP;
    }

    private void UpdateHearts()
    {
        foreach (Transform child in _vehicleHealthUI.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _HP; i++)
        {
            GameObject heart = Instantiate(_heartIcon, _vehicleHealthUI.transform);
        }
    }
}
