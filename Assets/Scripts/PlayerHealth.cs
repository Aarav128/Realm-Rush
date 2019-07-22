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

    EnemySpawner enemySpawner = null;
    int finalScore;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update() 
    {
        healthText.text = "Health: " + health.ToString();
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
        yield return StartCoroutine(GetComponent<SceneLoader>().LoadSceneAsync(gameOverSceneBuildIndex, 1f));
        ResetToNewScene();

        TextMeshProUGUI scoreText = FindObjectOfType<ScoreText>().GetComponent<TextMeshProUGUI>();
        if (scoreText != null)
        {
            scoreText.text = finalScore.ToString();
        }
        Destroy(gameObject);
    }

    private void ResetToNewScene()
    {
        finalScore = enemySpawner.GetScore();
        healthText.text = "";
        GetComponent<MeshRenderer>().enabled = false;
    }
}
