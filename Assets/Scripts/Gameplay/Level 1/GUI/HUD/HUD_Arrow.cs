using UnityEngine;
using System.Collections;

public class HUD_Arrow : MonoBehaviour
{
    GameObject GO_Head;
    public bool b_VisibleCheck = true;
    public bool b_isVisible = true;
    public GameObject GO_Target;
    public Vector3 v3_ArrowOffset;

    public Vector3 v3_HeadOffset;
    public MeshScaler MS_Scaler;

    Vector3 v3_arrow_rotation;
    Quaternion Q4_head_rotationCompensation;

    Vector3 v3_ScreenCheck;

    // Use this for initialization
    void Start()
    {
        GO_Head = GameObject.FindGameObjectWithTag("MainCamera");
        this.gameObject.AddComponent<MeshFader>();
        GetComponent<MeshFader>().f_fadeSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        v3_ScreenCheck = GO_Head.GetComponent<Camera>().WorldToViewportPoint(GO_Target.transform.position);
        if (b_isVisible)
        {
            if (b_VisibleCheck)
            {
                if (v3_ScreenCheck.x < 0 || v3_ScreenCheck.x > 1 || v3_ScreenCheck.y < 0 || v3_ScreenCheck.y > 1)
                {
                    GetComponent<MeshFader>().fadetoVisible();
                    MS_Scaler.setScaleDefault();
                }
                else
                {
                    GetComponent<MeshFader>().fadetoInvisible();
                    MS_Scaler.setScaleZero();
                }
            }
            else
            {
                GetComponent<MeshFader>().fadetoVisible();
                MS_Scaler.setScaleDefault();
            }
        }
        else
        {
            GetComponent<MeshFader>().fadetoInvisible();
            MS_Scaler.setScaleZero();
        }

        if (!GetComponent<MeshFader>().isInvisible())
        {
            Q4_head_rotationCompensation = GO_Head.transform.localRotation;

            v3_arrow_rotation = GO_Head.transform.position - GO_Target.transform.position + Q4_head_rotationCompensation * v3_HeadOffset;

            Q4_head_rotationCompensation.Set(-Q4_head_rotationCompensation.x, -Q4_head_rotationCompensation.y, -Q4_head_rotationCompensation.z, Q4_head_rotationCompensation.w);

            this.transform.localRotation = Q4_head_rotationCompensation * Quaternion.LookRotation(v3_arrow_rotation);

            this.transform.localPosition = this.transform.localRotation * v3_ArrowOffset;
        }
    }

    public void setInvisible(bool isit)
    {
        b_isVisible = isit;
    }
}
