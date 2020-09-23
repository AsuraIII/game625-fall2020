﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public ObjectType type;
        public GameObject prefab;
        public int poolSize;
    }

    public Transform objectParent;
    public List<Pool> poolList;
    public static Dictionary<ObjectType, Queue<GameObject>> poolDict;

    private void Awake()
    {

    }
    void Start()
    {
        poolDict = new Dictionary<ObjectType, Queue<GameObject>>();

        foreach (Pool pool in poolList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, objectParent);
                obj.SetActive(false);

                objectPool.Enqueue(obj);
            }
            poolDict.Add(pool.type, objectPool);
        }
    }

    public GameObject SpawnFromPool(ObjectType type, Vector3 position)
    {
        if (poolDict != null)
        {
            if (!poolDict.ContainsKey(type))
            {
                return null;
            }
            if (poolDict[type].Count > 0)
            {
                GameObject objectgToSpawn = poolDict[type].Dequeue();


                objectgToSpawn.SetActive(true);
                objectgToSpawn.transform.position = position;

                return objectgToSpawn;
            }

        }
        return null;
    }


}
public enum ObjectType
{
    Cube,
    Cylinder
}