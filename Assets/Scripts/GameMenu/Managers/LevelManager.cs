namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

    // If you added new scene, please add scene name to list last
    public enum Scenes
    {
        // Masujima's test scene
        UnknownScene,
        LogoScene,
        TitleScene,
        PlayScene,
        OptionsScene,
        ExitScene,

        // Glenn's test scene
		SampleGameplayLevel
    }

    public class LevelManager : MonoBehaviour
    {
        // Please attach scene.
        public Scenes currentlyScene;

        void Awake()
        {
            switch (currentlyScene)
            {
                case Scenes.UnknownScene:
                    Debug.LogError("There is unknown scene. So you have to fix it.");
                    Debug.Break();
                    break;
                case Scenes.LogoScene:
                    gameObject.AddComponent<LogoScene>();
                    break;
                case Scenes.TitleScene:
                    gameObject.AddComponent<TitleScene>();
                    break;
                case Scenes.PlayScene:
                    gameObject.AddComponent<PlayScene>();
                    break;
                case Scenes.OptionsScene:
                    gameObject.AddComponent<OptionsScene>();
                    break;
                case Scenes.ExitScene:
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
}