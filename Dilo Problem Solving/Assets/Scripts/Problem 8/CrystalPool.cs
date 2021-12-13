using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPool : MonoBehaviour
{
    Queue<GameObject> CrystalObjectPool;

    public void CreatePool(Transform parent, GameObject prefab, int size)
    {
        CrystalObjectPool = new Queue<GameObject>();
        for(int x = 0; x < size; x++)
        {
            GameObject gameObject = Instantiate(prefab, parent);
            gameObject.SetActive(false);
            CrystalObjectPool.Enqueue(gameObject);
        }

        //Debug.Log("CP called");
    }

    public void DespawnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        CrystalObjectPool.Enqueue(gameObject);
    }

    public GameObject SpawnFromPool()
    {
        GameObject gameObject = CrystalObjectPool.Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }
}


