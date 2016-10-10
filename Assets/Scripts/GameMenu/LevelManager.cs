using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum Scenes
{
    UNKNOWN,
    Logo,
    Title,
    Play,
    Options,
    Exit,
}

public class LevelManager : MonoBehaviour
{
    // Please attach scene.
    public Scenes currentlyScene;

    void Awake()
    {
        switch(currentlyScene)
        {
            case Scenes.UNKNOWN:
                Debug.LogError("There is unknown scene. So you have to fix it.");
                break;
            case Scenes.Logo:
                gameObject.AddComponent<LogoScene>();
                break;
            case Scenes.Title:
                gameObject.AddComponent<TitleScene>();
                break;
            case Scenes.Play:
                gameObject.AddComponent<PlayScene>();
                break;
            case Scenes.Options:
                gameObject.AddComponent<OptionsScene>();
                break;
            case Scenes.Exit:
                gameObject.AddComponent<ExitScene>();
                break;
            default:
                break;
        }
    }

    void Start()
    {
        //Debug.Log(currentlyScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
