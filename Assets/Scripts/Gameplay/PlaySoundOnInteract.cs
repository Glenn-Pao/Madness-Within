using UnityEngine;
using System.Collections;

public class PlaySoundOnInteract : MonoBehaviour
{
    public GameObject GO_SoundLocation;
    public PointerUIReceiver UI_InteractTrigger;
    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    public bool b_TriggerOnRelease = true;

    bool b_isReleased = false;
    // Use this for initialization
    void Start()
    {
        if (UI_InteractTrigger == null)
        {
            if (this.GetComponent<PointerUIReceiver>() != null)
            {
                UI_InteractTrigger = this.GetComponent<PointerUIReceiver>();
            }
            else
            {
                UI_InteractTrigger = this.gameObject.AddComponent<PointerUIReceiver>();
            }
        }

        if (GO_SoundLocation == null)
        {
            GO_SoundLocation = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_InteractTrigger.TriggerPressed() && !b_isReleased)
        {
            b_isReleased = true;

            if (!b_TriggerOnRelease)
            {
                RS_Sound.transform.position = GO_SoundLocation.transform.position;
                RS_Sound.rs3d_PlaySound();
            }
        }
        else if (!UI_InteractTrigger.TriggerPressed() && b_isReleased)
        {
            b_isReleased = false;

            if (b_TriggerOnRelease)
            {
                RS_Sound.transform.position = GO_SoundLocation.transform.position;
                RS_Sound.rs3d_PlaySound();
            }
        }
    }
}