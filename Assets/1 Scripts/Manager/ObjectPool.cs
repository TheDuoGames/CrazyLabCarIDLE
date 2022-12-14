using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class ObjectPool : MonoBehaviour
    {
        #region SerializedPool
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
            public Transform parent;
        }
        #endregion
        #region Singleton
        public static ObjectPool instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        public List<Pool> pools;
        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, pool.parent);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(pool.tag, objectPool);
            }
        }
        public GameObject GetObject(string tag, Vector3 position)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Böyle Bir Tag Bulunamadý : " + tag);
                return null;
            }
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
    } 
}