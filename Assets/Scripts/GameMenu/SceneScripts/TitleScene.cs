namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;


    public class TitleScene : SceneBase
    {
        public void Start()
        {
            AudioManager.instance.PlayBGM(BGM.RuefulMelody);
            StartCoroutine(AudioManager.instance.FourOnTheFloor());

        }


        // Update is called once per frame
        void Update()
        {
            AudioManager.instance.ChangeBGMVolume(AudioManager.instance.GetBGMVolume());
        }
    }
}