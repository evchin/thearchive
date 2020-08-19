using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    [SerializeField] OVRScreenFade fader;
    private int levelToLoad;

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        fader.FadeOut();
        SceneManager.LoadScene(levelToLoad);
        StartCoroutine("WaitForSceneLoad", levelToLoad);
        fader.OnLevelFinishedLoading(1);
    }

    IEnumerator WaitForSceneLoad(int levelToLoad)
    {
        while (SceneManager.GetActiveScene().buildIndex != levelToLoad)
        {
            yield return null;
        }
    }
}
