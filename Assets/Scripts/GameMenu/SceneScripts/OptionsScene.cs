namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;


    public class OptionsScene : SceneBase
    {

        #region [ VARIABLES ]

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
        void Start()
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
            StartCoroutine(FourOnTheFloor());

            //bgmSlider.
            //Debug.Log(PlayerPrefs.GetFloat(BGM_VOLUME, 0));
            //Debug.Log(PlayerPrefs.GetFloat(SE_VOLUME, 0));
            //Debug.Log(PlayerPrefs.GetFloat(PLAYER_SPEED, 0));
            //Debug.Log(PlayerPrefs.GetFloat(MOVEMENT_TYPE, 0));

            
        }

        // Update is called once per frame
        void Update()
        {
          //  bgmSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(BGM_VOLUME, bgmSlider.transform.position.x), 0, 0);

            AudioManager.instance.ChangeBothVolume(bgmSlider.GetValue() / 100, seSlider.GetValue() / 100);
            //AudioManager.instance.ChangeBothVolume(bgmSlider.GetValue() / 10, 10);
            Debug.Log(PlayerPrefs.GetFloat(BGM_VOLUME, 0));
        }

        public void Saving()
        {
            PlayerPrefs.SetFloat(BGM_VOLUME, bgmSlider.transform.position.x);
            PlayerPrefs.SetFloat(SE_VOLUME, seSlider.transform.position.x);
            PlayerPrefs.SetFloat(PLAYER_SPEED, mtSlider.transform.position.x);
            PlayerPrefs.SetFloat(MOVEMENT_TYPE, psSlider.transform.position.x);
            Debug.Log("Saved");

        }

        void Loading()
        {
            bgmSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(BGM_VOLUME, bgmSlider.transform.position.x), 0, 0);
            seSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(SE_VOLUME, seSlider.transform.position.x), 0, 0);
            mtSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(MOVEMENT_TYPE, mtSlider.transform.position.x), 0, 0);
            psSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(PLAYER_SPEED, psSlider.transform.position.x), 0, 0);
        }

        private IEnumerator FourOnTheFloor(float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            while (true)
            {
                AudioManager.instance.PlaySE(SE.Kick);
                yield return new WaitForSeconds(0.75f);
            }
        }
    }
}