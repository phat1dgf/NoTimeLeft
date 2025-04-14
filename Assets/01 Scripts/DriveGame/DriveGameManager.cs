using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DriveGameManager : M_MonoBehaviour
{
    private static DriveGameManager _instance;
    public static DriveGameManager Instance => _instance;

    [SerializeField] private VehicleController _vehicle;
    public VehicleController Vehicle => _vehicle;

    Coroutine _obstacleSpawnCoroutine;

    [SerializeField] private float _timer;
    [SerializeField] private float _roundTime;

    protected override void Reset()
    {
        base.Reset();
        _roundTime = 60;
        _timer = _roundTime;
    }
    private void Update()
    {
        CountdownTime();
    }
    private void CountdownTime()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _timer = 0f;
                GameManager.Instance.MoveToContextGame();
                _timer = _roundTime;
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _vehicle = FindAnyObjectByType<VehicleController>();
    }

    private void OnEnable()
    {
        _obstacleSpawnCoroutine = StartCoroutine(ObstacleSpawnCoroutine());
    }
    private void OnDisable()
    {
        if (_obstacleSpawnCoroutine == null) return;
        StopCoroutine(_obstacleSpawnCoroutine);
        _obstacleSpawnCoroutine = null;
    }


    IEnumerator ObstacleSpawnCoroutine()
    {
        while (true)
        {
            float spawnTimer = Random.Range(2f, 5f);
            yield return new WaitForSeconds(spawnTimer);

            float[] possibleY =
            {
            ObstacleSpawner.Instance.transform.position.y,
            ObstacleSpawner.Instance.transform.position.y + 3,
            ObstacleSpawner.Instance.transform.position.y - 3
        };

            float posY = possibleY[Random.Range(0, possibleY.Length)];
            Vector2 spawnPos = new Vector2(ObstacleSpawner.Instance.transform.position.x, posY);

            ObstacleSpawner.Instance.CreateObstacle(spawnPos, Quaternion.identity);
        }
    }


}
