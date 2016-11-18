using UnityEngine;
using System.Collections;

public class ControllerAnimation : MonoBehaviour
{
    public GameObject GO_Controller;
    public GameObject GO_LeftClaw;
    public GameObject GO_RightClaw;

    public GameObject GO_Tip;
    public GameObject GO_Button;

    public Color DefaultColor;
    public Color GrabbableColor;
    public Color FailedColor;

    Vector3 v3_ControllerPosL;
    Vector3 v3_ControllerPosR;
    Vector3 v3_ControllerPosLGrip;
    Vector3 v3_ControllerPosRGrip;

    // Use this for initialization
    void Start()
    {
        v3_ControllerPosL.Set(2.07f, 0.654f, -0.0658f);
        v3_ControllerPosR.Set(-2.07f, 0.654f, -0.0658f);
        v3_ControllerPosLGrip.Set(1.3f, 0.654f, -0.0658f);
        v3_ControllerPosRGrip.Set(-1.3f, 0.654f, -0.0658f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().grabPressed)
        {
            GO_LeftClaw.GetComponent<Translator>().move(v3_ControllerPosLGrip);
            GO_RightClaw.GetComponent<Translator>().move(v3_ControllerPosRGrip);

            if (GO_Controller.GetComponent<VRTK.VRTK_InteractGrab>().GetGrabbedObject() != null)
            {
                GO_Tip.GetComponent<MeshFader>().fadetoColour(GrabbableColor);
                GO_Button.GetComponent<MeshFader>().fadetoColour(GrabbableColor);
            }
            else
            {
                GO_Tip.GetComponent<MeshFader>().fadetoColour(FailedColor);
                GO_Button.GetComponent<MeshFader>().fadetoColour(FailedColor);
            }
            
        }
        else
        {
            GO_LeftClaw.GetComponent<Translator>().move(v3_ControllerPosL);
            GO_RightClaw.GetComponent<Translator>().move(v3_ControllerPosR);
            GO_Tip.GetComponent<MeshFader>().fadetoColour(DefaultColor);
            GO_Button.GetComponent<MeshFader>().fadetoColour(DefaultColor);
        }
    }
}
