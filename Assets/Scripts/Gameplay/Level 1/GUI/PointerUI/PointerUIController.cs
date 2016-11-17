using UnityEngine;
using System.Collections;

public class PointerUIController : MonoBehaviour
{
    public GameObject GO_Controller;
    public GameObject GO_Pointer;
    public GameObject GO_Circle1;
    public GameObject GO_Circle2;

    GameObject GO_HeldObject;

    public Color C_DefaultColor;
    public Color C_HoverColor;
    public Color C_ClickColor;

    public float f_Range = 0.3f;

    bool raycasted;

    Ray raycast;
    RaycastHit Rayhit;

    Vector3 v3_defaultScale;
    Vector3 v3_currentScale;

    // Use this for initialization
    void Start()
    {
        if (GO_Controller == null)
        {
            GO_Controller = this.gameObject;
        }

        v3_defaultScale = GO_Pointer.transform.localScale;
        v3_currentScale = v3_defaultScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (raycasted && Rayhit.transform != null && Rayhit.transform.gameObject != null && Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>().setHovering(false);
            Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>().setInteract(false);
        }

        if (GO_HeldObject != null && GO_HeldObject.GetComponent<PointerUIReceiver>() != null)
        {
            GO_HeldObject.GetComponent<PointerUIReceiver>().setHeldInteracted(false);
        }

        if (GO_Controller.GetComponent<VRTK.VRTK_InteractGrab>().GetGrabbedObject() == null)
        {
            if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerPressed)
            {
                raycasted = Physics.Raycast(raycast, out Rayhit, f_Range);

                scaleZto(f_Range / 3f * 2f);

                raycast.origin = GO_Controller.transform.position;
                raycast.direction = GO_Controller.transform.rotation * new Vector3(0, 0, 1);

                GO_Pointer.GetComponent<MeshFader>().fadetoColour(C_DefaultColor);
                    
                if (raycasted)
                {
                    if (Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>() != null)
                    {
                        Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>().setHovering(true);
                        GO_Pointer.GetComponent<MeshFader>().fadetoColour(C_HoverColor);

                        if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerClicked)
                        {
                            Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>().setInteract(true);
                            GO_Pointer.GetComponent<MeshFader>().fadetoColour(C_ClickColor);
                            GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
                        }
                        else
                        {
                            GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(100);
                        }
                    }
                }
            }
            else
            {
                scaleZto(0);
                GO_Pointer.GetComponent<MeshFader>().fadetoInvisible();
                GO_Circle1.GetComponent<MeshFader>().fadetoInvisible();
                GO_Circle2.GetComponent<MeshFader>().fadetoInvisible();
            }
        }
        else
        {
            scaleZto(0);
            GO_Pointer.GetComponent<MeshFader>().fadetoInvisible();
            GO_Circle1.GetComponent<MeshFader>().fadetoInvisible();
            GO_Circle2.GetComponent<MeshFader>().fadetoInvisible();
            

            if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerPressed)
            {
                GO_HeldObject = GO_Controller.GetComponent<VRTK.VRTK_InteractGrab>().GetGrabbedObject();

                GO_Circle1.GetComponent<MeshFader>().fadetoVisible();
                GO_Circle2.GetComponent<MeshFader>().fadetoVisible();

                GO_Circle1.transform.Rotate(0, 0, 2f);
                GO_Circle2.transform.Rotate(0, 0, -2f);

                if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerClicked)
                {
                    if (GO_HeldObject.GetComponent<PointerUIReceiver>() != null)
                    {
                        GO_HeldObject.GetComponent<PointerUIReceiver>().setHeldInteracted(true);
                    }

                    GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(250);
                }
                else
                {
                    GO_Controller.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(100);
                }
            }
        }

        GO_Pointer.transform.position.Set(GO_Pointer.transform.position.x, GO_Pointer.transform.position.y, v3_currentScale.z / 3f);
        GO_Pointer.transform.localScale = v3_currentScale;
    }

    void scaleZto(float z)
    {
        v3_currentScale.z += (z - v3_currentScale.z) * Time.deltaTime * 6f;
    }
}
