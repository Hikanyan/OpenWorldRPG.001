using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    private AsyncOperation _async;
    [SerializeField] GameObject _loadingUI;
    [SerializeField] Slider _slider;

    public static LoadingScene Instance;
    public Action LoadingComplete;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadNextScene(string sceneName)
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        _async = SceneManager.LoadSceneAsync(sceneName);

        while (!_async.isDone)
        {
            _slider.value = _async.progress;
            yield return null;
        }
        _loadingUI.SetActive(false);
        LoadingComplete?.Invoke();
    }

}
