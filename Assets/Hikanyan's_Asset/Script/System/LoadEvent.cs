using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEvent : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void OnclickLoadBotton()
    {
        Debug.Log($"Botton�������ꂽ����{_sceneName}�Ɉڍs");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
