using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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
                Instantiate(enemyPrefab);
                yield return new WaitForSeconds(secondsBetweenSpawns);
            }
    }
}
