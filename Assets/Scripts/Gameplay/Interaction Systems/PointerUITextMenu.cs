using UnityEngine;
using System.Collections;

public class PointerUITextMenu : MonoBehaviour
{
    public string message = "Hello World";
    public float f_Time = 3f;
    public Vector3 v3_Offset = new Vector3(0f, 0.065f, 0f);
    public PointerUIReceiver UI_InteractTrigger;
    public HologramText HTW_HologramText;

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
        if (HTW_HologramText == null)
        {
            HTW_HologramText = GameObject.FindGameObjectWithTag("HologramTextController").GetComponent<HologramText>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UI_InteractTrigger.TouchpadPressed())
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
