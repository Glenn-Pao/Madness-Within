namespace MasujimaRyohei
{
    using UnityEngine;
	#if UNITY_EDITOR
    using UnityEditor;
	#endif
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
#if UNITY_EDITOR

            if (!GameObject.Find("AudioManager"))
            {
                _audioManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "AutomaticPutting/AudioManager.prefab");
                Instantiate(_audioManager);
            }
            if (!GameObject.Find("FadeManager"))
            {
                _fadeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "AutomaticPutting/FadeManager.prefab");
                Instantiate(_fadeManager);
            }
            if (!GameObject.Find("TimeManager"))
            {
                _timeManager = (GameObject)AssetDatabase.LoadMainAssetAtPath(_managersPath + "AutomaticPutting/TimeManager.prefab");
                Instantiate(_timeManager);
            }
#else
            if (!GameObject.Find("AudioManager"))
            {
                _audioManager = (GameObject)Resources.Load("Prefabs/Managers/AutomaticPutting/AudioManager");
                Instantiate(_audioManager);
            }
            if (!GameObject.Find("FadeManager"))
            {
                _audioManager = (GameObject)Resources.Load("Prefabs/Managers/AutomaticPutting/AudioManager");
                Instantiate(_fadeManager);
            }
            if (!GameObject.Find("TimeManager"))
            {
                _audioManager = (GameObject)Resources.Load("Prefabs/Managers/AutomaticPutting/AudioManager");
                Instantiate(_timeManager);
            }
#endif
        }

        public void SetBGM(string bgmName)
        {
            AudioManager.instance.PlayBGM(bgmName);
        }
        public void PlaySE(string seName)
        {
            AudioManager.instance.PlaySE(seName);
        }
    }
}