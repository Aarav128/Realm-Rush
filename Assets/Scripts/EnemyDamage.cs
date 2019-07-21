using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 25;

    private void OnParticleCollision(GameObject other) 
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            KillEnemy(); // kill the enemy if it loses all its health
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
