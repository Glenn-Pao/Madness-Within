using UnityEngine;
using System.Collections;

public class Taser : MonoBehaviour
{
    public PointerUIReceiver UI_InteractTrigger;
    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    public ParticleSystem PS_System;
    public Light L_Light;

    public bool b_isUsing;
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
            b_isUsing = true;
            PS_System.enableEmission = true;
            L_Light.enabled = true;

            if (RS_Sound != null)
            {
                if (!RS_Sound.rs3d_IsPlaying())
                {
                    RS_Sound.rs3d_PlaySound();
                }
                RS_Sound.transform.position = this.transform.position;
            }
        }
        else
        {
            b_isUsing = false;
            PS_System.enableEmission = false;
            L_Light.enabled = false;
            RS_Sound.rs3d_StopSound();
        }
    }
}
