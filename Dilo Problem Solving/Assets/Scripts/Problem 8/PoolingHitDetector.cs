using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingHitDetector : MonoBehaviour
{
    ScoreController scoreController;
    CrystalPool crystalPool;
    CrystalPoolSpawner crystalPoolSpawner;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
        crystalPool = FindObjectOfType<CrystalPool>();
        crystalPoolSpawner = FindObjectOfType<CrystalPoolSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Crystal"))
        {
            scoreController.addScore();
            // Despawn crystal yang dihit lalu respawn setelah 3 detik
            crystalPool.DespawnToPool(collision.gameObject);
            crystalPoolSpawner.Respawn();
        }
    }
}
