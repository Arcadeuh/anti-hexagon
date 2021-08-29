using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Animator loadScreenAnimator;

    public void LoadByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadByStringAnim(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        loadScreenAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(0.333f);
        SceneManager.LoadScene(sceneName);
    }
}
