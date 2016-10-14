namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;


    public class OptionsScene : SceneBase
    {

        #region [ VARIABLES ]
        const string BGM_POS_X = "BGM_SLIDER_POS_X";
        const string BGM_POS_Y = "BGM_SLIDER_POS_Y";
        const string BGM_POS_Z = "BGM_SLIDER_POS_Z";
        const string SE_POS_X = "SE_SLIDER_POS_X";
        const string SE_POS_Y = "SE_SLIDER_POS_Y";
        const string SE_POS_Z = "SE_SLIDER_POS_Z";
        const string MT_POS_X = "MT_SLIDER_POS_X";
        const string MT_POS_Y = "MT_SLIDER_POS_Y";
        const string MT_POS_Z = "MT_SLIDER_POS_Z";
        const string PS_POS_X = "PS_SLIDER_POS_X"; 
        const string PS_POS_Y = "PS_SLIDER_POS_Y"; 
        const string PS_POS_Z = "PS_SLIDER_POS_Z";

      //  public const string BGM_VOLUME = "BGM_VOLUME";

        Transform sounds, player;
        Transform bgm, se;
        Transform movementType, playerSpeed;

        VRTK.VRTK_Control bgmSlider, seSlider;
        VRTK.VRTK_Control mtSlider, psSlider;

        float temp;
        #endregion

        #region [ KEY_DEFINES ]

        const string BGM_VOLUME = "bgmVolume";
        const string SE_VOLUME = "seVolume";
        const string PLAYER_SPEED = "playerSpeed";
        const string MOVEMENT_TYPE = "movementType";

        #endregion
        // Use this for initialization
        public void Start()
        {
            #region [ INITIALIZE ]

            sounds = GameObject.Find("Sliders").transform.FindChild("Sounds");
            player = GameObject.Find("Sliders").transform.FindChild("Player");

            bgm = sounds.gameObject.transform.FindChild("BGM");
            se = sounds.gameObject.transform.FindChild("SE");
            movementType = player.gameObject.transform.FindChild("MovementType");
            playerSpeed = player.gameObject.transform.FindChild("PlayerSpeed");

            bgmSlider = bgm.transform.FindChild("Slider").GetComponent<VRTK.VRTK_Control>();
            seSlider = se.transform.FindChild("Slider").GetComponent<VRTK.VRTK_Control>();

            mtSlider = movementType.transform.FindChild("Slider").GetComponent<VRTK.VRTK_Control>();
            psSlider = playerSpeed.transform.FindChild("Slider").GetComponent<VRTK.VRTK_Control>();

            Loading();

            #endregion

            SetBGM(BGM.RuefulMelody);
            StartCoroutine(AudioManager.instance.FourOnTheFloor());

            Loading();
        }

        // Update is called once per frame
        void Update()
        {
            SetBGM(BGM.RuefulMelody);

            AudioManager.instance.ChangeBGMVolume(AudioManager.instance.GetBGMVolume());

            AudioManager.instance.ChangeBothVolume(bgmSlider.GetValue() / 100, seSlider.GetValue() / 100);
            //AudioManager.instance.ChangeBothVolume(bgmSlider.GetValue() / 10, 10);
            //Debug.Log(SaveData.GetFloat(BGM_VOLUME, 0));
        }

        public void Saving()
        {
            SaveData.SetFloat(BGM_POS_X, bgmSlider.transform.position.x);
            SaveData.SetFloat(SE_POS_X, seSlider.transform.position.x);
            SaveData.SetFloat(MT_POS_X, mtSlider.transform.position.x);
            SaveData.SetFloat(PS_POS_X, psSlider.transform.position.x);
            SaveData.SetFloat(BGM_POS_Y, bgmSlider.transform.position.y);
            SaveData.SetFloat(SE_POS_Y, seSlider.transform.position.y);
            SaveData.SetFloat(MT_POS_Y, mtSlider.transform.position.y);
            SaveData.SetFloat(PS_POS_Y, psSlider.transform.position.y);
            SaveData.SetFloat(BGM_POS_Z, bgmSlider.transform.position.z);
            SaveData.SetFloat(SE_POS_Z, seSlider.transform.position.z);
            SaveData.SetFloat(MT_POS_Z, mtSlider.transform.position.z);
            SaveData.SetFloat(PS_POS_Z, psSlider.transform.position.z);

            SaveData.Save();
            Debug.Log("Just finished saving the data.");
        }

        public void Loading()
        {
            bgmSlider.transform.position = new Vector3(SaveData.GetFloat(BGM_POS_X), SaveData.GetFloat(BGM_POS_Y), SaveData.GetFloat(BGM_POS_Z));
            seSlider.transform.position = new Vector3(SaveData.GetFloat(SE_POS_X), SaveData.GetFloat(SE_POS_Y), SaveData.GetFloat(SE_POS_Z));
            mtSlider.transform.position = new Vector3(SaveData.GetFloat(MT_POS_X), SaveData.GetFloat(MT_POS_Y), SaveData.GetFloat(MT_POS_Z));
            psSlider.transform.position = new Vector3(SaveData.GetFloat(PS_POS_X), SaveData.GetFloat(PS_POS_Y), SaveData.GetFloat(PS_POS_Z));
        }

    }
}