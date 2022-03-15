using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;

    public SmoothLoader smoothLoader;

    public void LoadScene(string sceneName)
    {
        smoothLoader.SceneToLoad = sceneName;
        smoothLoader.enabled = true;

        loadingScreen.SetActive(true);
        menuScreen.SetActive(false);
    }
}