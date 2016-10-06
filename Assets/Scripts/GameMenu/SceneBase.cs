using UnityEngine;
using System.Collections;

public class SceneBase : MonoBehaviour
{
    private GameObject _audioManager;
    private GameObject _fadeManager;
    private GameObject _timeManager;

    public void Awake()
    {
        if (!GameObject.Find("AudioManager"))
        {
            _audioManager = (GameObject)Resources.Load("Prefabs/AudioManager");   
            Instantiate(_audioManager);
        }
        if (!GameObject.Find("FadeManager"))
        {
            _fadeManager = (GameObject)Resources.Load("Prefabs/FadeManager");
            Instantiate(_fadeManager);
        }
        if (!GameObject.Find("TimeManager"))
        {
            _timeManager = (GameObject)Resources.Load("Prefabs/TimeManager");
            Instantiate(_timeManager);
        }
    }
}
