using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : M_MonoBehaviour
{
    [SerializeField] private Image _foodBar;
    [SerializeField] private Image _energyBar;
    [SerializeField] private Image _fuelBar;
    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        LoadPlayerStats();
    }

    private void LoadPlayerStats()
    {
        playerStats = playerController.Instance.PlayerStats;
    }

    private void Update()
    {
        _foodBar.fillAmount = playerStats.Food / 10f;
        _energyBar.fillAmount = playerStats.Energy / 10f;
        _fuelBar.fillAmount = playerStats.Fuel / 10f;
    }
}
