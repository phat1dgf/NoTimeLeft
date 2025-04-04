using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : M_MonoBehaviour
{
    private static ObstacleSpawner _instance;
    public static ObstacleSpawner Instance => _instance;

    [SerializeField] private GameObject obstacle;
    private Dictionary<Obstacle, GameObject> _obstacleMap;
    private Dictionary<GameObject, List<GameObject>> _pool;

    Coroutine _obstacleSpawnCoroutine;


    protected override void Awake()
    {
        base.Awake();
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if(this.gameObject.GetInstanceID() == _instance.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnEnable()
    {
        _obstacleMap = new Dictionary<Obstacle, GameObject>();
        _pool = new Dictionary<GameObject, List<GameObject>>();
        _obstacleMap[Obstacle.obstacle] = obstacle;
    }

    public GameObject CreateObstacle(Obstacle type, Vector2 position, Quaternion rotation)
    {
        GameObject prefab = _obstacleMap[type];

        if (!_pool.ContainsKey(prefab))
        {
            _pool[prefab] = new List<GameObject>();
        }

        foreach(GameObject obj in _pool[prefab])
        {
            if (obj.activeSelf) continue;
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj; 
        }

        GameObject newObj = Instantiate(prefab,position,rotation);
        newObj.transform.parent = this.transform;
        _pool[prefab].Add(newObj);
        return newObj;
    }

    public enum Obstacle
    {
        obstacle
    }
    
}
