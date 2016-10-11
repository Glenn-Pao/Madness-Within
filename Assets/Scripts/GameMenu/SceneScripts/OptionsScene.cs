using UnityEngine;
using System.Collections;


public class OptionsScene : SceneBase {

    Transform sounds,player;
    Transform bgm,se;
    Transform movementType, playerSpeed;

    VRTK.VRTK_Control bgmSlider,seSlider;
    VRTK.VRTK_Control mtSlider,psSlider;

    const string BGM_VOLUME = "bgmVolume";
    const string SE_VOLUME = "seVolume";
    const string PLAYER_SPEED = "playerSpeed";
    const string MOVEMENT_TYPE = "movementType";

	// Use this for initialization
	void Start () {
        SetBGM(BGM.RuefulMelody);

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
        
        //bgmSlider.transform.position = new Vector3(PlayerPrefs.GetFloat(BGM_VOLUME, 0), 0, 0);
        //bgmSlider.transform.position = new Vector3(0.f, 0, 0);
        Debug.Log(PlayerPrefs.GetFloat(BGM_VOLUME, 0));
        Debug.Log(PlayerPrefs.GetFloat(SE_VOLUME, 0));
        Debug.Log(PlayerPrefs.GetFloat(PLAYER_SPEED, 0));
        Debug.Log(PlayerPrefs.GetFloat(MOVEMENT_TYPE, 0));
    }
	
	// Update is called once per frame
	void Update () {

        AudioManager.instance.ChangeBGMVolume(bgmSlider.GetValue() / 10);
        Saving();
        

	}

    void Saving()
    {
        PlayerPrefs.SetFloat(BGM_VOLUME, bgmSlider.transform.position.x);
        PlayerPrefs.SetFloat(SE_VOLUME, seSlider.transform.position.x);
        PlayerPrefs.SetFloat(PLAYER_SPEED, mtSlider.transform.position.x);
        PlayerPrefs.SetFloat(MOVEMENT_TYPE, psSlider.transform.position.x);

    }
}
