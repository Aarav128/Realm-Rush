using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 6.5f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Transform enemyParent = null;

    private void Start() 
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

        private IEnumerator RepeatedlySpawnEnemies()
        {
            while (true) // forever
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyParent);
                yield return new WaitForSeconds(secondsBetweenSpawns);
            }
    }
}
