using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public IEnumerator LoadSceneAsync(int buildIndex, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        yield return SceneManager.LoadSceneAsync(buildIndex);
    }
}
