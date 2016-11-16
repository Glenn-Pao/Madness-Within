using UnityEngine;
using System.Collections;

public class HologramTextWorld : MonoBehaviour
{
    GameObject GO_Head;
    public MeshScaler MS_Scaler;
    public float f_Speed = 1f;

    public bool b_EnableHudArrow = true;
    HUD_Arrow HUD_ARROW;

    Quaternion Q_UIRotation;

    bool b_isVisible = false;
    float f_fadeOutTimer = 0f;
    Color c_TextColor;
    Color c_LineColor;

    bool b_NextQueue = false;
    Vector3 v3_NextPos = new Vector3(0f, 0f, 0f);
    string s_NextText = "";

    public GameObject GO_Line;

    // Use this for initialization
    void Start()
    {
        if (b_EnableHudArrow)
        {
            HUD_ARROW = GameObject.FindGameObjectWithTag("HUDArrow").GetComponent<HUD_Arrow>();
        }
        GetComponent<TextMesh>().text = s_NextText;
        GO_Head = GameObject.FindGameObjectWithTag("MainCamera");

        c_TextColor = this.GetComponent<Renderer>().material.color;
        c_TextColor.a = 0f;

        //GO_Line = this.transform.FindChild("Line").gameObject;

        c_LineColor = GO_Line.GetComponent<MeshRenderer>().material.color;
        c_LineColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //setMessage(new Vector3(1.466f, 2.85f, -20.85f), "TEST MESSAGE PLS\nIGNORE", 10f);

        if (b_isVisible)
        {
            if (c_TextColor.a < 1f)
            {
                c_TextColor.a += Time.deltaTime * f_Speed;
                c_LineColor.a += Time.deltaTime * f_Speed;
            }
            else
            {
                c_TextColor.a = 1f;
                c_LineColor.a = 1f;
            }

            if (f_fadeOutTimer > 0f)
            {
                f_fadeOutTimer -= Time.deltaTime;
            }
            else
            {
                b_isVisible = false;
            }
            
            MS_Scaler.setScaleDefault();

            if (b_EnableHudArrow)
            {
                HUD_ARROW.setVisible(true);
            }
        }
        else
        {
            if (c_TextColor.a > 0f)
            {
                c_TextColor.a -= Time.deltaTime * f_Speed;
                c_LineColor.a -= Time.deltaTime * f_Speed;
            }
            else
            {
                c_TextColor.a = 0f;
                c_LineColor.a = 0f;

                if (b_NextQueue)
                {
                    this.transform.position = v3_NextPos;
                    GetComponent<TextMesh>().text = s_NextText;
                    b_isVisible = true;
                    b_NextQueue = false;
                }
            }

            MS_Scaler.setScaleZero();

            if (b_EnableHudArrow)
            {
                HUD_ARROW.setVisible(false);
            }
        }

        this.GetComponent<Renderer>().material.color = c_TextColor;
        GO_Line.GetComponent<MeshRenderer>().material.color = c_LineColor;

        this.transform.rotation = Quaternion.LookRotation(this.transform.position - GO_Head.transform.position);
    }

    public void setMessage(Vector3 Position, string Text, float Time)
    {
        s_NextText = Text;
        v3_NextPos = Position;
        f_fadeOutTimer = Time;

        if (!b_NextQueue)
        {
            if (!b_isVisible)
            {
                this.transform.position = Position;
                GetComponent<TextMesh>().text = Text;
                b_isVisible = true;
            }
            else
            {
                b_NextQueue = true;
                b_isVisible = false;
            }
        }
    }
    public bool getIsVisible()
    {
        return b_isVisible;
    }
}
