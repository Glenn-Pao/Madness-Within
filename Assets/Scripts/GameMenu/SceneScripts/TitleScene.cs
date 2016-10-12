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
        }


        // Update is called once per frame
        void Update()
        {
        }
    }
}