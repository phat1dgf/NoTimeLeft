using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveGameManager : M_MonoBehaviour
{
    private static DriveGameManager _instance;
    public static DriveGameManager Instance => _instance;

    Coroutine _obstacleSpawnCoroutine;

    protected override void Awake()
    {
        base.Awake();
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        if(_instance.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _obstacleSpawnCoroutine = StartCoroutine(ObstacleSpawnCoroutine());
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
        while(true)
        {
            float spawnTimer = UnityEngine.Random.Range(4f, 7f);
            yield return new WaitForSeconds(spawnTimer);

            float[] possibleY =
            {
                ObstacleSpawner.Instance.transform.position.y,
                ObstacleSpawner.Instance.transform.position.y + 3.5f,
                ObstacleSpawner.Instance.transform.position.y - 3.5f
            };

            float posY = possibleY[UnityEngine.Random.Range(0, possibleY.Length)];
            Vector2 spawnPos = new Vector2(ObstacleSpawner.Instance.transform.position.x, posY);
            ObstacleSpawner.Instance.CreateObstacle(ObstacleSpawner.Obstacle.obstacle, spawnPos, Quaternion.identity);
        }
    }
}
