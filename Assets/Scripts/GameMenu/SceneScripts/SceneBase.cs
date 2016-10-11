using UnityEngine;
using UnityEditor;
using System.Collections;

public class SceneBase : MonoBehaviour
{
    private string _managersPath = "Assets/Prefabs/Managers/";

    protected GameObject _audioManager;
    protected GameObject _fadeManager;
    protected GameObject _timeManager;

    public AudioClip currentlyBGM;

    private void Awake()
    {
        if (!GameObject.Find("AudioManager"))
        {
            _audioManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "UnneedPutting/AudioManager.prefab");
            Instantiate(_audioManager);
        }
        if (!GameObject.Find("FadeManager"))
        {
            _fadeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "UnneedPutting/FadeManager.prefab");
            Instantiate(_fadeManager);
        }
        if (!GameObject.Find("TimeManager"))
        {
            _timeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "UnneedPutting/TimeManager.prefab");
            Instantiate(_timeManager);
        }
    }

    public void SetBGM(string bgmName)
    {
        AudioManager.instance.PlayBGM(bgmName);
    }
}
