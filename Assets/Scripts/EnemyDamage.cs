using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab = null;
    [SerializeField] ParticleSystem deathParticlePrefab = null;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
