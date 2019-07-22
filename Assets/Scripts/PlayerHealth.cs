using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] TextMeshProUGUI healthText = null;
    [SerializeField] AudioClip enemyReachedSFX = null;

    EnemySpawner enemySpawner = null;

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
        health--;
        enemySpawner.ChangeScore(-10);
    }
}
