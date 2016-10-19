namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class TestPlayer
    {
        [SerializeField]
        public int hp;
        public float attack;
        public string name;
        public List<string> items;
        public TestPlayer()
        {
            items = new List<string>();
            items.Add("Potion");
            items.Add("Sword");
            items.Add("Gun");
            hp = 50;
            attack = 18.5f;
            name = "Jeff";
        }
    }

    public class HowToUseSaveData : MonoBehaviour
    {
        // First of all,
        // I made SaveData.cs script.
        // It's able to save any datas(int, float, class, etc..) to Json file.
        // It's just like PlayerPref class.
        // But unlike PleyerPref-class SaveData-class is able to add other operations.
        // Anyway, this is the extension of PlayerPref-class.
        void Start()
        {
            #region [ HOW_TO_GET_AUDIO_VOLUME_AND_PLAYER_DATA ]

            float bgmVolume;
            /// If you need BGM volume, you have 2 ways.
            /// You can get same value as both.
            /// 1st way.
            bgmVolume = AudioManager.instance.GetBGMVolume();
            /// 2nd way.(Recommended way)
            bgmVolume = SaveData.GetFloat(BGM.VOLUME);

            /// SE-Volume,PlayerSpeed,MovementType
            /// You can get the above values in a similar manner

            // seVolume = SaveData.GetFloat(SE.VOLUME);
            // movementType = SaveData.GetFloat(PLAYER.MOVEMENT_TYPE);
            // playerSpeed = SaveData.GetFloat(PLAYER.SPEED);

            /// Don't forget to use Save function!!!!!
            SaveData.Save();

            #endregion

            #region [ HOW_TO_SAVE_ANY_DATA ]
            /// NOTICE
            /// At this point you can save other data except int, float, string, list, any-class.

            int inum = 5;
            SaveData.SetInt("INT_NUMBER_KEY", inum);

            //float fnum = 5.0f;
            //SaveData.SetFloat("FLOAT_NUMBER_KEY", fnum);

            //string str = "Yandere";
            //SaveData.SetString("STRING_KEY", str);

            //List<string> names = new List<string>();
            //names.Add("Glenn");
            //names.Add("Ryohei");
            //names.Add("Joon Kiat");
            //names.Add("Amanda");
            //names.Add("Cheryl");

            //SaveData.SetList<string>("LIST_KEY",names);

            SaveData.SetClass<TestPlayer>("TEST_PLAYER_KEY", new TestPlayer());

            #endregion
        }
    }
}