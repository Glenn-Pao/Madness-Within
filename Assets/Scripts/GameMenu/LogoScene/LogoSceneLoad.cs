using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoSceneLoad : MonoBehaviour {

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
