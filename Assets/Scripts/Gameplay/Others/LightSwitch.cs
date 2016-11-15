using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{
    public Light[] lightSources;
    public PointerUIReceiver UI_InteractTrigger;
    public bool b_lightSwitchOn = false;

    public float f_SwitchOnRotation;
    public float f_SwitchOffRotation;

    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    float f_CurrentRotation;

    Vector3 v3_Rotation;

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

        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i].enabled = b_lightSwitchOn;
        }

        f_CurrentRotation = f_SwitchOffRotation;
        v3_Rotation = this.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_InteractTrigger.Interacted() && !b_isReleased)
        {
            b_isReleased = true;
        }
        else if (!UI_InteractTrigger.Interacted() && b_isReleased)
        {
            b_isReleased = false;

            if (b_lightSwitchOn)
                b_lightSwitchOn = false;
            else
                b_lightSwitchOn = true;

            for (int i = 0; i < lightSources.Length; i++)
            {
                lightSources[i].enabled = b_lightSwitchOn;
            }

            RS_Sound.transform.position = this.transform.position;
            RS_Sound.rs3d_PlaySound();
        }

        if (b_lightSwitchOn)
        {
            if (f_CurrentRotation != f_SwitchOnRotation)
            {
                if (Mathf.Abs(f_SwitchOnRotation - f_CurrentRotation) > 0.01)
                {
                    f_CurrentRotation += (f_SwitchOnRotation - f_CurrentRotation) * Time.deltaTime * 5f;
                }
                else
                {
                    f_CurrentRotation = f_SwitchOnRotation;
                }
            }
        }
        else
        {
            if (f_CurrentRotation != f_SwitchOffRotation)
            {
                if (Mathf.Abs(f_SwitchOffRotation - f_CurrentRotation) > 0.01)
                {
                    f_CurrentRotation += (f_SwitchOffRotation - f_CurrentRotation) * Time.deltaTime * 5f;
                }
                else
                {
                    f_CurrentRotation = f_SwitchOffRotation;
                }
            }
        }
        //GetComponent<RealSpace3D.RealSpace3D_AudioSource>().rs3d_PlaySound("light_switch.ogg");
        
        v3_Rotation.x = f_CurrentRotation;
        this.transform.localRotation = Quaternion.Euler(v3_Rotation);
    }
}