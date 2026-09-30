using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : Singleton<SceneLoaderManager>
{
    public void Load(string sceneName) => SceneManager.LoadScene(sceneName);

    // This one is made for UnityEvents, specifically in the Story scene
    public void LoadAfterDelay(string sceneName) => StartCoroutine(LoadAfterDelayCoroutine(sceneName, 1));
    public void LoadAfterDelay(string sceneName, float delay) => StartCoroutine(LoadAfterDelayCoroutine(sceneName, delay));

    private IEnumerator LoadAfterDelayCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        Load(sceneName);
    }
}