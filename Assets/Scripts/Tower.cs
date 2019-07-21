using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float attackRange = 10f;

    private void Update()
    {
        if (targetEnemy != null)
        {
            FireAtEmemy();
        }
        else
        {
            Shoot(false); // Don't shoot if there isn't an enemy
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Display the attack range when selected
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void FireAtEmemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        ParticleSystem.EmissionModule emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
