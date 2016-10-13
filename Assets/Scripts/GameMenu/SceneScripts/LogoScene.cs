namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

    public class LogoScene : SceneBase
    {

        private void Start()
        {
            Debug.Log("StartLogoScene");
            SetBGM(BGM.RuefulMelody);
            Invoke("SceneLoad", 5);
        }

        void SceneLoad()
        {
            Debug.Log("LoadNextScene");

            SceneManager.LoadScene("TitleScene");
        }
    }
}