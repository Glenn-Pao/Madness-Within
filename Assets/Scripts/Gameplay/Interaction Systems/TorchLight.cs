using UnityEngine;
using System.Collections;

public class TorchLight : MonoBehaviour
{
    public Light L_Light;
    public Light L_Light2;
    public PointerUIReceiver UI_InteractTrigger;
    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    bool b_isReleased = false;
    

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
        if (UI_InteractTrigger.TriggerPressed() && !b_isReleased)
        {
            b_isReleased = true;
        }
        else if (!UI_InteractTrigger.TriggerPressed() && b_isReleased)
        {
            b_isReleased = false;

            if (L_Light.enabled)
                L_Light.enabled = false;
            else
                L_Light.enabled = true;

            if (L_Light2 != null)
            {
                if (L_Light2.enabled)
                    L_Light2.enabled = false;
                else
                    L_Light2.enabled = true;
            }

            RS_Sound.transform.position = this.transform.position;
            RS_Sound.rs3d_PlaySound();
        }
    }
}
