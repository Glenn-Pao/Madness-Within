using UnityEngine;
using System.Collections;

public class PointerUIMenu : MonoBehaviour
{
    public MeshScaler MScaler;
    public PointerUIReceiver UI_InteractTrigger;
    public float f_Range = 1.5f;
    public bool b_RotateToPlayer = false;
    GameObject GO_Head;
    

    bool b_isReleased = false;
    bool b_isVisible = false;

    // Use this for initialization
    void Start()
    {
        GO_Head = GameObject.FindGameObjectWithTag("MainCamera");

        if (MScaler == null)
        {
            MScaler = this.GetComponent<MeshScaler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = UI_InteractTrigger.TriggerPressed();
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
            MScaler.setScaleDefault();

            if (Vector3.Magnitude(GO_Head.transform.position - this.transform.position) > f_Range)
            {
                b_isVisible = false;
            }
        }
        else
        {
            MScaler.setScaleZero();
        }

        if (b_RotateToPlayer)
        {
            this.transform.rotation = Quaternion.LookRotation(this.transform.position - GO_Head.transform.position);
        }
    }
}
