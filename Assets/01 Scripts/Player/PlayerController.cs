using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : M_MonoBehaviour
{
    private static playerController _instance;
    public static playerController Instance => _instance;

    [SerializeField] private PlayerStats _playerStats;
    public PlayerStats PlayerStats => _playerStats;

    protected override void Awake()
    {
        base.Awake();
        if( _instance == null)
        {
            _instance = this;
            return;
        }
        if(_instance.gameObject.GetInstanceID()!= this.gameObject.GetInstanceID())
        {
            Destroy(gameObject);
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerStats();
    }

    private void LoadPlayerStats()
    {
        _playerStats = GetComponentInChildren<PlayerStats>();
    }
}
