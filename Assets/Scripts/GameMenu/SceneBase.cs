using UnityEngine;
using UnityEditor;
using System.Collections;

public class SceneBase : MonoBehaviour
{
    protected GameObject _audioManager;
    protected GameObject _fadeManager;
    protected GameObject _timeManager;

    public AudioClip bgm;

    public void Awake()
    {
        if (!GameObject.Find("AudioManager"))
        {
            _audioManager = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Managers/AudioManager.prefab");
            Debug.Log(_audioManager);
            Instantiate(_audioManager);
        }
        if (!GameObject.Find("FadeManager"))
        {
            _fadeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Managers/FadeManager.prefab");
            Instantiate(_fadeManager);
        }
        if (!GameObject.Find("TimeManager"))
        {
            _timeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Managers/TimeManager.prefab");
            Instantiate(_timeManager);
        }
    }
}
