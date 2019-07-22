using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 6.5f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Transform enemyParent = null;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [Range(1, 50)]
    [SerializeField] int scoreGain = 5;
    [SerializeField] AudioClip enemySpawnSFX = null;
    [Range(0f, 10f)]
    [Tooltip("When to start spawning enemies after game start")] [SerializeField] float startSpawnDelay = 1f;

    private int score = 0;

    private void Start() 
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private IEnumerator RepeatedlySpawnEnemies()
    {
        yield return new WaitForSeconds(startSpawnDelay); // delay the spawning of enemies
        while (true) // forever
        {
            SpawnEnemy();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyParent);
        score += scoreGain;
        GetComponent<AudioSource>().PlayOneShot(enemySpawnSFX);
    }

    public void ChangeScore(int scoreChange)
    {
        score += scoreChange;
    }
}
