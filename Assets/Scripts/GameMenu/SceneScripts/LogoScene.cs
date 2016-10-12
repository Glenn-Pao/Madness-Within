namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

    [RequireComponent(typeof(SceneBase))]
    public class LogoScene : MonoBehaviour
    {

        private void Start()
        {
            Debug.Log("StartLogoScene");
            Invoke("SceneLoad", 5);
        }

        void SceneLoad()
        {
            Debug.Log("LoadNextScene");

            SceneManager.LoadScene("TitleScene");
        }
    }
}