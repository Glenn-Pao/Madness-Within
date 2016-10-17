namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;

    using VRTK;

    public class OptionsScene : SceneBase
    {

        #region [ VARIABLES ]
        const string BGM_POS_X = "BGM_SLIDER_POS_X_KEY";
        const string BGM_POS_Y = "BGM_SLIDER_POS_Y_KEY";
        const string BGM_POS_Z = "BGM_SLIDER_POS_Z_KEY";
        const string SE_POS_X = "SE_SLIDER_POS_X_KEY";
        const string SE_POS_Y = "SE_SLIDER_POS_Y_KEY";
        const string SE_POS_Z = "SE_SLIDER_POS_Z_KEY";
        const string MT_POS_X = "MT_SLIDER_POS_X_KEY";
        const string MT_POS_Y = "MT_SLIDER_POS_Y_KEY";
        const string MT_POS_Z = "MT_SLIDER_POS_Z_KEY";
        const string PS_POS_X = "PS_SLIDER_POS_X_KEY";
        const string PS_POS_Y = "PS_SLIDER_POS_Y_KEY";
        const string PS_POS_Z = "PS_SLIDER_POS_Z_KEY";

      //  public const string BGM_VOLUME = "BGM_VOLUME";

        private Transform s, p;     // sounds player
        private Transform bgm, se;
        private Transform mt, ps;   // movementType playerSpeed

        // Sliders
        private VRTK_Control bgms, ses;
        private VRTK_Control mts, pss;

        #endregion

        #region [ KEY_DEFINES ]

        // const string BGM_VOLUME = "bgmVolume";
        // const string SE_VOLUME = "seVolume";
        // const string PLAYER_SPEED = "playerSpeed";
        // const string MOVEMENT_TYPE = "movementType";

        #endregion
        // Use this for initialization
        public void Start()
        {
            #region [ INITIALIZE ]

            s = GameObject.Find("Sliders").transform.FindChild("Sounds");
            p = GameObject.Find("Sliders").transform.FindChild("Player");

            bgm = s.gameObject.transform.FindChild("BGM");
            se = s.gameObject.transform.FindChild("SE");
            mt = p.gameObject.transform.FindChild("MovementType");
            ps = p.gameObject.transform.FindChild("PlayerSpeed");

            bgms = bgm.transform.FindChild("Slider").GetComponent<VRTK_Control>();
            ses = se.transform.FindChild("Slider").GetComponent<VRTK_Control>();

            mts = mt.transform.FindChild("Slider").GetComponent<VRTK_Control>();
            pss = ps.transform.FindChild("Slider").GetComponent<VRTK_Control>();

            Loading();

            #endregion

            SetBGM(BGM.TITLE.RuefulMelody);
            StartCoroutine(AudioManager.instance.FourOnTheFloor());

            Loading();
        }

        // Update is called once per frame
        private void Update()
        {
           SetBGM(BGM.TITLE.RuefulMelody);

            AudioManager.instance.ChangeBGMVolume(AudioManager.instance.GetBGMVolume());

            AudioManager.instance.ChangeBothVolume(bgms.GetValue() / 100, ses.GetValue() / 100);
            ///AudioManager.instance.ChangeBothVolume(bgmSlider.GetValue() / 10, 10);
           ///Debug.Log(SaveData.GetFloat(BGM_VOLUME, 0));
        }

        public void Saving()
        {
            ///!    To save the sliders value, you need using those position.  

            SaveData.SetFloat( BGM_POS_X, bgms.transform.position.x);
            SaveData.SetFloat( SE_POS_X,  ses.transform.position.x );
            SaveData.SetFloat( MT_POS_X,  mts.transform.position.x );
            SaveData.SetFloat( PS_POS_X,  pss.transform.position.x );
            SaveData.SetFloat( BGM_POS_Y, bgms.transform.position.y);
            SaveData.SetFloat( SE_POS_Y,  ses.transform.position.y );
            SaveData.SetFloat( MT_POS_Y,  mts.transform.position.y );
            SaveData.SetFloat( PS_POS_Y,  pss.transform.position.y );
            SaveData.SetFloat( BGM_POS_Z, bgms.transform.position.z);
            SaveData.SetFloat( SE_POS_Z,  ses.transform.position.z );
            SaveData.SetFloat( MT_POS_Z,  mts.transform.position.z );
            SaveData.SetFloat( PS_POS_Z,  pss.transform.position.z );

            SaveData.Save();
            // Debug.Log("Just finished saving the data.");
        }

        public void Loading()
        {
            // Set the saved data to the sliders position.
            bgms.transform.position = new Vector3(SaveData.GetFloat(BGM_POS_X, bgms.transform.position.x), SaveData.GetFloat(BGM_POS_Y, bgms.transform.position.y), SaveData.GetFloat(BGM_POS_Z, bgms.transform.position.z));
            ses.transform.position =  new Vector3(SaveData.GetFloat(SE_POS_X , ses.transform.position.x),  SaveData.GetFloat(SE_POS_Y,  ses.transform.position.y ), SaveData.GetFloat(SE_POS_Z , ses.transform.position.z));
            mts.transform.position =  new Vector3(SaveData.GetFloat(MT_POS_X , mts.transform.position.x),  SaveData.GetFloat(MT_POS_Y,  mts.transform.position.y),  SaveData.GetFloat(MT_POS_Z , mts.transform.position.z));
            pss.transform.position =  new Vector3(SaveData.GetFloat(PS_POS_X , pss.transform.position.x),  SaveData.GetFloat(PS_POS_Y,  pss.transform.position.y),  SaveData.GetFloat(PS_POS_Z , pss.transform.position.z));
        }

    }
}