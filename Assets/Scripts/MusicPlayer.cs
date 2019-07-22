using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static bool hasBeenSpawned = false;
    private void Awake() 
    {
        if (hasBeenSpawned)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            hasBeenSpawned = true;
        }
    }
}
