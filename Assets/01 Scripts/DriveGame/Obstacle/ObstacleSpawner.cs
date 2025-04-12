using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : M_MonoBehaviour
{
    private static ObstacleSpawner _instance;
    public static ObstacleSpawner Instance => _instance;

    [SerializeField] private List<GameObject> obstacles;

    private Dictionary<GameObject, List<GameObject>> _pool;

    protected override void Awake()
    {
        base.Awake();
        if (_instance == null)
        {
            _instance = this;
            return;
        }

        if (this.gameObject.GetInstanceID() == _instance.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        _pool = new Dictionary<GameObject, List<GameObject>>();
    }

    public GameObject CreateObstacle(Vector2 position, Quaternion rotation)
    {
        if (obstacles == null || obstacles.Count == 0)
        {
            Debug.LogWarning("Obstacle list is empty!");
            return null;
        }

        GameObject prefab = obstacles[Random.Range(0, obstacles.Count)];

        if (!_pool.ContainsKey(prefab))
        {
            _pool[prefab] = new List<GameObject>();
        }

        foreach (GameObject obj in _pool[prefab])
        {
            if (!obj.activeSelf)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab, position, rotation, this.transform);
        _pool[prefab].Add(newObj);
        return newObj;
    }
}
