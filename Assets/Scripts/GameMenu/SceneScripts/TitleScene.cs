namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;


    public class TitleScene : SceneBase
    {
        public void Start()
        {
            StartCoroutine(AudioManager.instance.FourOnTheFloor());

        }


        // Update is called once per frame
        void Update()
        {
            SetBGM(BGM.TITLE.RuefulMelody);
            ChangeBothVolume(SaveData.GetFloat(BGM.VOLUME, BGM.DEFAULT.VOLUME), SaveData.GetFloat(SE.VOLUME, SE.DEFAULT.VOLUME));
        }
    }
}