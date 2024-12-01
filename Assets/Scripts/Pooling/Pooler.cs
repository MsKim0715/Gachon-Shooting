using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public class Pooler : MonoBehaviour
    {
        public static Pooler Instance;

        [SerializeField] private Pool[] pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;
        private List<GameObject> _spawnobj;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            _spawnobj = new List<GameObject>();
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (var pool in pools)
            {
                _poolDictionary.Add(pool.tag, new Queue<GameObject>());
                for (var i = 0; i < pool.size; i++)
                {
                    var obj = CreateObj(pool.tag, pool.prefab);
                    ArrangeObj(obj);
                }
            }
        }

        public GameObject GetObj(string objTag)
        {
            var poolQueue = _poolDictionary[objTag];
            if (poolQueue.Count <= 0)
            {
                var pool = Array.Find(pools, x => x.tag == objTag);
                var obj = CreateObj(pool.tag, pool.prefab);
                ArrangeObj(obj);
            }

            var spawnObj = poolQueue.Dequeue();
            spawnObj.SetActive(true);
            return spawnObj;
        }

        public void ReturnObj(GameObject obj)
        {
            obj.SetActive(false);
            _poolDictionary[obj.name].Enqueue(obj);
        }

        private GameObject CreateObj(string objTag, GameObject prefab)
        {
            var obj = Instantiate(prefab, transform);
            obj.name = objTag;
            obj.SetActive(false);
            _poolDictionary[obj.name].Enqueue(obj);
            return obj;
        }

        private void ArrangeObj(GameObject obj)
        {
            var isFind = false;
            for (var i = 0; i < transform.childCount; i++)
            {
                if (i == transform.childCount - 1)
                {
                    obj.transform.SetSiblingIndex(i);
                    _spawnobj.Insert(i, obj);
                    break;
                }

                if (transform.GetChild(i).name == obj.name)
                {
                    isFind = true;
                }
                else if (isFind)
                {
                    obj.transform.SetSiblingIndex(i);
                    _spawnobj.Insert(i, obj);
                    break;
                }
            }
        }

        [Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }
    }
}