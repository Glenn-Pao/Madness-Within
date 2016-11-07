using UnityEngine;
using System.Collections;

public class MeshScaler : MonoBehaviour
{
    Vector3 v3_DefaultScale;
    Vector3 v3_CurrentScale;

    public float b_ScaleSpeed = 3f;
    public bool b_ScaleZero = true;
    // Use this for initialization
    void Start()
    {
        v3_DefaultScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_ScaleZero)
        {
            v3_CurrentScale.x += (0 - v3_CurrentScale.x) * Time.deltaTime * b_ScaleSpeed;
            v3_CurrentScale.y += (0 - v3_CurrentScale.y) * Time.deltaTime * b_ScaleSpeed;
            v3_CurrentScale.z += (0 - v3_CurrentScale.z) * Time.deltaTime * b_ScaleSpeed;

            if (Mathf.Abs(0 - v3_CurrentScale.x) < 0.01f)
            {
                v3_CurrentScale.Set(0f, 0f, 0f);
            }
        }
        else
        {
            v3_CurrentScale.x += (v3_DefaultScale.x - v3_CurrentScale.x) * Time.deltaTime * b_ScaleSpeed;
            v3_CurrentScale.y += (v3_DefaultScale.y - v3_CurrentScale.y) * Time.deltaTime * b_ScaleSpeed;
            v3_CurrentScale.z += (v3_DefaultScale.z - v3_CurrentScale.z) * Time.deltaTime * b_ScaleSpeed;

            if (Mathf.Abs(v3_DefaultScale.x - v3_CurrentScale.x) < 0.01f)
            {
                v3_CurrentScale = v3_DefaultScale;
            }
        }

        this.transform.localScale = v3_CurrentScale;
    }

    public void setScaleZero()
    {
        b_ScaleZero = false;
    }

    public void setScaleDefault()
    {
        b_ScaleZero = true;
    }
}
