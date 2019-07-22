using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab = null;
    [SerializeField] ParticleSystem deathParticlePrefab = null;
    [SerializeField] AudioClip enemyHitSFX = null;
    [SerializeField] AudioClip enemyDeathSFX = null;

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
        GetComponent<AudioSource>().PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        Destroy(vfx.gameObject, vfx.main.duration);

        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position); // plays the death sound at the location of the main camera

        Destroy(gameObject);
    }
}
