using UnityEngine;
using System.Collections;

public class PointerUIMenu : MonoBehaviour
{
    public MeshScaler MScaler;
    public PointerUIReceiver UI_InteractTrigger;

    bool b_isReleased = false;
    bool b_isVisible = false;

    // Use this for initialization
    void Start()
    {
        if (MScaler == null)
        {
            MScaler = this.GetComponent<MeshScaler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = UI_InteractTrigger.Interacted();
        if (temp && !b_isReleased)
        {
            b_isReleased = true;
        }
        else if (!temp && b_isReleased)
        {
            b_isReleased = false;

            if (b_isVisible)
                b_isVisible = false;
            else
                b_isVisible = true;
        }

        if (b_isVisible)
        {
            MScaler.setScaleZero();
        }
        else
        {
            MScaler.setScaleDefault();
        }
    }
}
