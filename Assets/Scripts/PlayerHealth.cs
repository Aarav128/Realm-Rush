using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] TextMeshProUGUI healthText = null;
    [SerializeField] AudioClip enemyReachedSFX = null;
    [SerializeField] int gameOverSceneBuildIndex;

    [SerializeField] EnemySpawner enemySpawner = null;
    int finalScore;

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (health > 0)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        GetComponent<AudioSource>().PlayOneShot(enemyReachedSFX);
        health = Mathf.Max(0, health - 1);

        if (health == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        ResetToNewScene();
        yield return StartCoroutine(GetComponent<SceneLoader>().LoadSceneAsync(gameOverSceneBuildIndex, 1f));

        TextMeshProUGUI scoreText = FindObjectOfType<ScoreText>().GetComponent<TextMeshProUGUI>();
        scoreText.text = finalScore.ToString();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void ResetToNewScene()
    {
        finalScore = enemySpawner.GetScore();
        healthText.text = "";
        GetComponent<MeshRenderer>().enabled = false;
    }
}
 