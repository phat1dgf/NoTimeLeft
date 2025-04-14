using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : M_MonoBehaviour
{
  

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

    

    private void Start()
    {
        _food = 2;
        _energy = 2;
        _fuel = 5;
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
            Debug.Log("GameOver");
            GameOver();
        }
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void AddFood(int food)
    {
        if(_food + food >= _maxFood)
        {
            _food = _maxFood;
            return;
        }
        this._food += food;
        Debug.Log("FOOD "+_food);
    }
    public void ReduceFood(int food)
    {
        this._food -= food;
    }
    public void AddEnergy(int energy)
    {
        if (_energy + energy >= _maxEnergy)
        {
            _energy = _maxEnergy;
            return;
        }
        this._energy += energy;
        Debug.Log("ENERGY "+_energy);
    }
    public void ReduceEnergy(int energy)
    {
        this._energy -= energy;
        
    }
    public void AddFuel(int fuel)
    {
        if (_fuel + fuel >= _maxFuel)
        {
            _fuel = _maxFuel;
            return;
        }
        this._fuel += fuel;
        Debug.Log("FUEL "+_fuel);
    }
    public void ReduceFuel(int fuel)
    {
        this._fuel -= fuel;
    }
}
