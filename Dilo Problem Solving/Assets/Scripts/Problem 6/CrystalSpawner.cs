using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] SpawnPointConfig[] spawnPoint;

    //[SerializeField] int spawnAmount = 3;
    //[SerializeField] float spawnPointRadius = 1;

    void Start()
    {
        SpawnCrystal();    
    }

    private void SpawnCrystal()
    {
        for (int x = 0; x < spawnPoint.Length; x++)
        {
            for (int y = 0; y < spawnPoint[x].amount; y++)
            {
                Vector2 randomPos = Random.insideUnitCircle * spawnPoint[x].radius;
                randomPos += (Vector2)spawnPoint[x].spawnTransform.position;
                Instantiate(prefab, randomPos, Quaternion.identity, spawnPoint[x].spawnTransform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < spawnPoint.Length; x++)
        {
            Gizmos.DrawWireSphere(spawnPoint[x].spawnTransform.position, spawnPoint[x].radius);
        }
    }
}

[System.Serializable]
public struct SpawnPointConfig
{
    public Transform spawnTransform;
    public float radius;
    public int amount;
}
