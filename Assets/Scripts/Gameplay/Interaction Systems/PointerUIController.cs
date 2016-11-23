using UnityEngine;
using System.Collections;

public class PointerUIController : MonoBehaviour
{
    public GameObject GO_Controller;
    public GameObject GO_Circle1;
    public GameObject GO_Circle2;

    GameObject GO_HeldObject;

    public Color C_DefaultColor;
    public Color C_HoverColor;
    public Color C_ClickColor;

    public AuraViveInteractCollider AVIC_Collider;

    public bool b_isLeftController = false;

    bool b_TouchReleaseChecked = false;
    bool b_ReleaseChecked = false;

    // Use this for initialization
    void Start()
    {
        if (GO_Controller == null)
        {
            GO_Controller = this.gameObject;
        }
    }

    void FixedUpdate()
    {
        GO_Circle1.GetComponent<MeshFader>().fadetoInvisible();
        GO_Circle2.GetComponent<MeshFader>().fadetoInvisible();

        /*//When you touch a object
        if (AVIC_Collider.GO_TouchedObject != null && AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>() != null && !b_TouchReleaseChecked)
        {
            //AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>().setTouchpad(false);
            //AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>().setTrigger(false);
            b_TouchReleaseChecked = true;
        }

        //When you interact with object IN HAND
        if (GO_HeldObject != null && GO_HeldObject.GetComponent<PointerUIReceiver>() != null && GO_HeldObject.GetComponent<PointerUIReceiver>().b_EnableInteractTrigger && !b_ReleaseChecked)
        {
            //GO_HeldObject.GetComponent<PointerUIReceiver>().setTouchpad(false);
            //GO_HeldObject.GetComponent<PointerUIReceiver>().setTrigger(false);
            b_ReleaseChecked = true;
        }//*/

        //When you interact with object IN HAND
        if (GO_Controller.GetComponent<VRTK.VRTK_InteractGrab>().GetGrabbedObject() != null)
        {
            GO_HeldObject = GO_Controller.GetComponent<VRTK.VRTK_InteractGrab>().GetGrabbedObject();

            b_ReleaseChecked = false;

            if (GO_HeldObject.GetComponent<PointerUIReceiver>() != null)
            {
                GO_Circle1.transform.Rotate(0, 0, 1f);
                GO_Circle2.transform.Rotate(0, 0, -1f);

                GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_DefaultColor);
                GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_DefaultColor);

                if (GO_HeldObject.GetComponent<PointerUIReceiver>().b_EnableInteractTrigger)
                {
                    GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_HoverColor);
                    GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_HoverColor);

                    if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerClicked)
                    {
                        GO_Circle1.transform.Rotate(0, 0, 2f);
                        GO_Circle2.transform.Rotate(0, 0, -2f);

                        GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_ClickColor);
                        GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_ClickColor);

                        GO_HeldObject.GetComponent<PointerUIReceiver>().setTrigger(true);

                        GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
                    }
                }
            }

            if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().touchpadPressed && !b_isLeftController)
            {
                GO_HeldObject.GetComponent<PointerUIReceiver>().setTouchpad(true);
                GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
            }
        }
        
        if (AVIC_Collider.b_isTouching && AVIC_Collider.GO_TouchedObject != null)//When you touch a object
        {
            b_TouchReleaseChecked = false;

            if (AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>() != null)
            {
                GO_Circle1.transform.Rotate(0, 0, 1f);
                GO_Circle2.transform.Rotate(0, 0, -1f);

                if (AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>().b_EnableInteractTrigger)
                {
                    GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_HoverColor);
                    GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_HoverColor);

                    if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerClicked)
                    {
                        GO_Circle1.transform.Rotate(0, 0, 2f);
                        GO_Circle2.transform.Rotate(0, 0, -2f);

                        GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_ClickColor);
                        GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_ClickColor);

                        AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>().setTrigger(true);
                        GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
                    }
                }
                else
                {
                    GO_Circle1.GetComponent<MeshFader>().fadetoColour(C_DefaultColor);
                    GO_Circle2.GetComponent<MeshFader>().fadetoColour(C_DefaultColor);
                }

                if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().touchpadPressed && !b_isLeftController)
                {
                    AVIC_Collider.GO_TouchedObject.GetComponent<PointerUIReceiver>().setTouchpad(true);
                    GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
                }
            }
        }
    }
}
