using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPoolSpawner : MonoBehaviour
{
    [SerializeField] Transform poolParent;
    [SerializeField] LayerMask playerLayer;

    private CrystalPool crystalPool;
    private int totalSize;

    [SerializeField] GameObject prefab;
    [SerializeField] SpawnPointConfig[] spawnPoint;


    void Awake()
    {
        crystalPool = FindObjectOfType<CrystalPool>();

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            totalSize += spawnPoint[i].amount;
        }

        // Inisiasi Pool
        InitiateCrystalPool();

        //Debug.Log(totalSize);
    }

    private void InitiateCrystalPool()
    {
        crystalPool.CreatePool(poolParent, prefab, totalSize);
        // Spawn crystal dari pool
        SpawnCrystal();

        //Debug.Log("SC called");
    }

    private void SpawnCrystal()
    {
        int spawnPointindex = 0;
        Vector2 randomPos = Vector2.zero;
        GameObject crystalObject;
        Collider2D overlap;

        for (int x = 0; x < totalSize; x++)
        {
            // Randomisasi spawner
            spawnPointindex = Random.Range(0, spawnPoint.Length);

            bool checkOverlap = true;
            //int i = 0;

            while (checkOverlap)
            {
                // Randomisasi lokasi pada spawner yang didapat
                randomPos = Random.insideUnitCircle * spawnPoint[spawnPointindex].radius;
                randomPos += (Vector2)spawnPoint[spawnPointindex].spawnTransform.position;
                
                // Cek apakah crystal akan tumpuk dengan player jika di spawn
                overlap = Physics2D.OverlapCircle(randomPos, 0.3f);
                
                // Jika tidak bertumpuk dengan player
                if (overlap == null)
                {
                    checkOverlap = false;
                    
                    crystalObject = crystalPool.SpawnFromPool();
                    crystalObject.transform.position = randomPos;
                    
                }
                //Debug.Log(checkOverlap);
                //i++;
                //Debug.Log(i);
            }
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCrystal());
    }

    private IEnumerator RespawnCrystal()
    {
        int spawnPointindex = 0;
        Vector2 randomPos = Vector2.zero;
        GameObject crystalObject;
        Collider2D overlap;
        bool checkOverlap = true;

        // Tunggu 3 detik sebelum spawn
        yield return new WaitForSeconds(3f);

        // Randomisasi spawner
        spawnPointindex = Random.Range(0, spawnPoint.Length);

        //int i = 0;

        while (checkOverlap)
        {
            // Randomisasi lokasi pada spawner yang didapat
            randomPos = Random.insideUnitCircle * spawnPoint[spawnPointindex].radius;
            randomPos += (Vector2)spawnPoint[spawnPointindex].spawnTransform.position;

            // Cek apakah crystal akan tumpuk dengan player jika di spawn
            overlap = Physics2D.OverlapCircle(randomPos, 0.3f);

            // Jika tidak bertumbukan dengan player
            if (overlap == null)
            {
                checkOverlap = false;

                crystalObject = crystalPool.SpawnFromPool();
                crystalObject.transform.position = randomPos;

            }
            //Debug.Log(checkOverlap);
            //i++;
            //Debug.Log(i);
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
