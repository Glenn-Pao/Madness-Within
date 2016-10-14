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
            SetBGM(BGM.RuefulMelody);
            ChangeBothVolume(SaveData.GetFloat(BGM.VOLUME), SaveData.GetFloat(SE.VOLUME));
        }
    }
}