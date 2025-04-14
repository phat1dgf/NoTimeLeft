using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : M_MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance => _instance;

    [SerializeField] private PlayerStats _playerStats;
    public PlayerStats PlayerStats => _playerStats;

    protected override void Awake()
    {
        base.Awake();
        if( _instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
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
