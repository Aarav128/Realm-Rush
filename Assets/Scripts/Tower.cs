﻿using UnityEngine;

public class Tower : MonoBehaviour
{
    public Waypoint baseWaypoint; // what the tower is standing on

    [SerializeField] Transform objectToPan = null;
    [SerializeField] ParticleSystem projectileParticles = null;
    [SerializeField] float attackRange = 10f;
    [SerializeField] float turnSpeed = 5f;

    Transform targetEnemy = null;

    private void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            FireAtEmemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) return; // Check if there are any enemies

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEmemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy <= attackRange)
        {
            FaceTarget();
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }

    private void FaceTarget()
    {
        Vector3 direction = (targetEnemy.position - objectToPan.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        objectToPan.rotation = Quaternion.Slerp(objectToPan.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() // Shows range
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
