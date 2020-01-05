using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
    }

    public void LoadTestLevel()
    {
        StartCoroutine(LoadTestLevelAsync());

    }

    public IEnumerator LoadTestLevelAsync()
    {
        var loading = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        while (!loading.isDone)
        {
            yield return null;
        }

        loading = SceneManager.LoadSceneAsync("TestShip", LoadSceneMode.Additive);
        while (!loading.isDone)
        {
            yield return null;
        }
    }

    public void Hide()
    {

    }

    public void Show()
    {

    }
}
