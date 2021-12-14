using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingHitDetector : MonoBehaviour
{
    ScoreController scoreController;
    CrystalPool crystalPool;
    CrystalPoolSpawner crystalPoolSpawner;

    // 9
    [SerializeField] GameObject crystalParticlePrefab;

    private void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        crystalPool = FindObjectOfType<CrystalPool>();
        crystalPoolSpawner = FindObjectOfType<CrystalPoolSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Crystal"))
        {
            // Tambahkan score
            scoreController.addScore();

            // Play particle effect
            GameObject crystalParticle = Instantiate(crystalParticlePrefab);
            if (crystalParticle != null)
            {
                crystalParticle.transform.position = collision.transform.position;
                crystalParticle.GetComponent<ParticleSystem>().Play();
                StartCoroutine(destroyParticle(crystalParticle));
            }

            // Despawn crystal yang dihit lalu respawn setelah 3 detik
            crystalPool.DespawnToPool(collision.gameObject);
            crystalPoolSpawner.Respawn();
        }
    }

    private IEnumerator destroyParticle(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
