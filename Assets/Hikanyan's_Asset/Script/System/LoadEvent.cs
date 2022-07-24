using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEvent : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void OnclickLoadBotton()
    {
        Debug.Log($"Botton‚ª‰Ÿ‚³‚ê‚½‚½‚ß{_sceneName}‚ÉˆÚs");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
