using UnityEngine;
using System.Collections;

//the door that will be brought down will need to take in the time
public class Door : MonoBehaviour 
{
    public Hinge[] Hinges;         //the door hinges

    void Update()
    {
        if (canBreakDoor())
        {
            if (this.GetComponent<PointerUITextMenu>() != null)
            {
                GameObject.Destroy(this.GetComponent<PointerUITextMenu>());

                if (this.GetComponent<VRTK.VRTK_InteractableObject>() != null && this.GetComponent<VRTK.VRTK_InteractableObject>().enabled == false)
                {
                    this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
                }
            }

            if (this.GetComponent<PointerUIReceiver>().TriggerPressed())
            {
                if (this.GetComponent<Rigidbody>() != null)
                {
                    this.GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<Rigidbody>().AddForce(0f, 0f, 500f);
                }
            }
        }
    }

    bool canBreakDoor()
    {
        for (int i = 0; i < Hinges.Length; i++)
        {
            if (!Hinges[i].getIsDestroyed())
            {
                return false;
            }
        }

        return true;
    }
}
