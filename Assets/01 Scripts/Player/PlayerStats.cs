using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : M_MonoBehaviour
{
    private static PlayerStats _instance;
    public static PlayerStats Instance => _instance;

    [SerializeField] private int _food;
    public int Food => _food;
    [SerializeField] private int _maxFood;
    public int MaxFood => _maxFood;
    [SerializeField] private int _energy;
    public int Energy => _energy;

    [SerializeField] private int _maxEnergy;
    public int MaxEnergy => _maxEnergy;
    [SerializeField] private int _fuel;
    public int Fuel => _fuel;
    [SerializeField] private int _maxFuel;
    public float MaxFuel => _maxFuel;

    protected override void Awake()
    {
        base.Awake();
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        if(_instance.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    protected override void Reset()
    {
        base.Reset();
        _maxEnergy = 10;
        _maxFood = 10;
        _maxFuel = 10;
    }

    private void Update()
    {
        StatsTracking();
    }
    private void StatsTracking()
    {
        if(_food <= 0 || _fuel <= 0 || _energy <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void AddFood(int food)
    {
        this._food += food;
    }
    public void AddEnergy(int energy)
    {
        this._energy += energy;
    }
    public void AddFuel(int fuel)
    {
        this._fuel += fuel;
    }
}
