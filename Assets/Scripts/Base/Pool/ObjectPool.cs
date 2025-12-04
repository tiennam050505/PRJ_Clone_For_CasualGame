using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   public static ObjectPool Instance;

    [System.Serializable]
    public class PoolItem
    {
        public string poolName;        // Tên để gọi object
        public GameObject prefab;      // Prefab cần tạo
        public int preloadAmount = 10; // Số lượng tạo sẵn
    }

    [SerializeField] private List<PoolItem> poolItems = new List<PoolItem>();

    // Dictionary lưu danh sách object theo tên
    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitPools();
    }

    private void InitPools()
    {
        foreach (var item in poolItems)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();

            for (int i = 0; i < item.preloadAmount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(this.transform);
                objectQueue.Enqueue(obj);
            }

            poolDictionary[item.poolName] = objectQueue;
        }
    }

    /// <summary>
    /// Get object from pool by name
    /// </summary>
    public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning($"Pool with name {poolName} does not exist!");
            return null;
        }

        GameObject objectToSpawn;

        // Nếu pool rỗng thì tạo thêm
        if (poolDictionary[poolName].Count == 0)
        {
            var prefab = poolItems.Find(p => p.poolName == poolName).prefab;
            objectToSpawn = Instantiate(prefab);
        }
        else
        {
            objectToSpawn = poolDictionary[poolName].Dequeue();
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    /// <summary>
    /// return object to pool
    /// </summary>
    public void ReturnToPool(string poolName, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(this.transform);

        if (!poolDictionary.ContainsKey(poolName))
        {
            poolDictionary[poolName] = new Queue<GameObject>();
        }

        poolDictionary[poolName].Enqueue(obj);
    }
}
