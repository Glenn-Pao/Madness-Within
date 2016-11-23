using UnityEngine;
using System.Collections;

public class EndDoor : MonoBehaviour
{
    public PointerUIReceiver UI_InteractTrigger;
    public GeneratorFailure GF_GeneratorFail;
    bool b_unlocked = false;
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
        UI_InteractTrigger.b_EnableInteractTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GF_GeneratorFail.b_EventTriggered && GF_GeneratorFail.b_PowerUp && GF_GeneratorFail.b_PutFireOut && !b_unlocked)
        {
            b_unlocked = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().AddForce(0f, 0f, 10f);
        }

        if (this.GetComponent<PointerUIReceiver>().TriggerPressed())
        {
            if (this.GetComponent<Rigidbody>() != null && !this.GetComponent<Rigidbody>().isKinematic)
            {
                this.GetComponent<Rigidbody>().AddForce(0f, 0f, 10f);
            }
        }
    }
}
