using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float spawnTime = 3.0f;
    private ObjectPooler objectPooler;

    private void Start()
    {
        if (objectPooler == null)
        {
            objectPooler = FindObjectOfType<ObjectPooler>();
        }

        StartCoroutine(ObjectSpawn(spawnTime));
    }

    private IEnumerator ObjectSpawn(float time)
    {
        while (true)
        {
            objectPooler.SpawnFromPool(ObjectType.Cube, RandomPosition());
            yield return new WaitForSeconds(time);
        }
    }
    public Vector3 RandomPosition()
    {
        float xRandom = Random.Range(-9.5f, 9.5f);
        float zRandom = Random.Range(-9.5f, 9.5f);

        Vector3 randomPos = new Vector3(xRandom, 0.5f, zRandom);
        return randomPos;
    }
}
