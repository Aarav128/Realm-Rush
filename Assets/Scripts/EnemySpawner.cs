using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab = null;

    private void Start() 
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

        private IEnumerator RepeatedlySpawnEnemies()
        {
            while (true) // forever
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(secondsBetweenSpawns);
            }
    }
}
