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

    public float f_BlinkRate = 0.5f;
    float f_Blink = 0f;

    bool b_Blink = false;

    Vector3 v3_arrow_rotation;
    Quaternion Q4_head_rotationCompensation;

    Vector3 v3_ScreenCheck;

    // Use this for initialization
    void Start()
    {
        GO_Head = GameObject.FindGameObjectWithTag("MainCamera");
        this.gameObject.AddComponent<MeshFader>();
        GetComponent<MeshFader>().f_fadeSpeed = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_isVisible)
        {
            v3_ScreenCheck = GO_Head.GetComponent<Camera>().WorldToViewportPoint(GO_Target.transform.position);
            if (b_VisibleCheck)
            {
                if ((v3_ScreenCheck.x < 0.3 || v3_ScreenCheck.x > 0.7 || v3_ScreenCheck.y < 0.3 || v3_ScreenCheck.y > 0.7) || v3_ScreenCheck.z < 0)
                {
                    f_Blink += Time.deltaTime;
                    if (f_Blink > f_BlinkRate)
                    {
                        f_Blink = 0f;

                        if (b_Blink)
                            b_Blink = false;
                        else
                            b_Blink = true;
                    }

                    if (b_Blink)
                    {
                        GetComponent<MeshFader>().fadetoVisible();
                    }
                    else
                    {
                        GetComponent<MeshFader>().fadetoInvisible();
                    }
                }
                else
                {
                    GetComponent<MeshFader>().fadetoInvisible();
                }
            }
            else
            {
                f_Blink += Time.deltaTime;
                if (f_Blink > f_BlinkRate)
                {
                    f_Blink = 0f;

                    if (b_Blink)
                        b_Blink = false;
                    else
                        b_Blink = true;
                }

                if (b_Blink)
                {
                    GetComponent<MeshFader>().fadetoVisible();
                }
                else
                {
                    GetComponent<MeshFader>().fadetoInvisible();
                }
            }
        }
        else
        {
            GetComponent<MeshFader>().fadetoInvisible();
        }

        if (b_isVisible)
        {
            Q4_head_rotationCompensation = GO_Head.transform.localRotation;

            v3_arrow_rotation = GO_Head.transform.position - GO_Target.transform.position + Q4_head_rotationCompensation * v3_HeadOffset;

            Q4_head_rotationCompensation.Set(-Q4_head_rotationCompensation.x, -Q4_head_rotationCompensation.y, -Q4_head_rotationCompensation.z, Q4_head_rotationCompensation.w);

            this.transform.localRotation = Q4_head_rotationCompensation * Quaternion.LookRotation(v3_arrow_rotation);
            this.transform.localPosition = this.transform.localRotation * v3_ArrowOffset;
        }
    }

    public void setVisible(bool isit)
    {
        b_isVisible = isit;
    }

    void setTarget(GameObject gameObject)
    {
        GO_Target = gameObject;
    }
}
