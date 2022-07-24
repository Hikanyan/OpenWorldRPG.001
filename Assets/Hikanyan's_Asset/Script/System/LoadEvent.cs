using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEvent : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void OnclickLoadBotton()
    {
        Debug.Log($"Bottonが押されたため{_sceneName}に移行");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
