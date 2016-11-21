using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour
{
    public PointerUIReceiver UI_InteractTrigger;
    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    public GameObject GO_SoundPos;
    public ParticleSystem PS_System;

    // Use this for initialization
    void Start()
    {
        if (this.GetComponent<PointerUIReceiver>() == null)
        {
            UI_InteractTrigger = this.gameObject.AddComponent<PointerUIReceiver>();
        }
        else
            UI_InteractTrigger = this.GetComponent<PointerUIReceiver>();

        UI_InteractTrigger.b_EnableInteractTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_InteractTrigger.TriggerPressed())
        {
            PS_System.enableEmission = true;

            if (RS_Sound != null)
            {
                if (!RS_Sound.rs3d_IsPlaying())
                {
                    RS_Sound.rs3d_PlaySound();
                }
                RS_Sound.transform.position = GO_SoundPos.transform.position;
            }
        }
        else
        {
            PS_System.enableEmission = false;
            RS_Sound.rs3d_StopSound();
        }
    }
}
