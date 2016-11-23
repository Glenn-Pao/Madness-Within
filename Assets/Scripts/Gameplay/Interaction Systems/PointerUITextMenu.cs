using UnityEngine;
using System.Collections;

public class PointerUITextMenu : MonoBehaviour
{
    public string message = "Hello World";
    public float f_Time = 3f;
    public PointerUIReceiver UI_InteractTrigger;
    public HologramText HTW_HologramText;
    public bool b_UseTriggerInstead = false;
    public bool b_UseBoth = false;

    private bool isInteracted = false;

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

        if (b_UseTriggerInstead)
        {
            UI_InteractTrigger.b_EnableInteractTrigger = true;
        }

        if (HTW_HologramText == null)
        {
            HTW_HologramText = GameObject.FindGameObjectWithTag("HologramTextController").GetComponent<HologramText>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (((UI_InteractTrigger.TouchpadPressed() && !b_UseTriggerInstead) || (UI_InteractTrigger.TriggerPressed() && b_UseTriggerInstead)) || b_UseBoth && (UI_InteractTrigger.TouchpadPressed() || UI_InteractTrigger.TriggerPressed()))
        {
            HTW_HologramText.setMessage(message, f_Time);
            isInteracted = true;
        }
        else
        {
            isInteracted = false;
        }
    }
    public bool getInteracted()
    {
        return isInteracted;
    }
}
