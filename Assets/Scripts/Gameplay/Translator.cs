using UnityEngine;
using System.Collections;

public class Translator : MonoBehaviour
{
    public Vector3 v3_CurrentPos;
    public float f_Speed = 1f;

    Vector3 v3_Target;

    // Use this for initialization
    void Start()
    {
        v3_Target = v3_CurrentPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (v3_Target.x != v3_CurrentPos.x)
        {
            v3_CurrentPos.x += (v3_Target.x - v3_CurrentPos.x) * Time.deltaTime * f_Speed;

            if (Mathf.Abs(v3_Target.x - v3_CurrentPos.x) < 0.01)
            {
                v3_CurrentPos.x = v3_Target.x;
            }
        }

        if (v3_Target.y != v3_CurrentPos.y)
        {
            v3_CurrentPos.y += (v3_Target.y - v3_CurrentPos.y) * Time.deltaTime * f_Speed;

            if (Mathf.Abs(v3_Target.y - v3_CurrentPos.y) < 0.01)
            {
                v3_CurrentPos.y = v3_Target.y;
            }
        }

        if (v3_Target.z != v3_CurrentPos.z)
        {
            v3_CurrentPos.z += (v3_Target.z - v3_CurrentPos.z) * Time.deltaTime * f_Speed;

            if (Mathf.Abs(v3_Target.z - v3_CurrentPos.z) < 0.01)
            {
                v3_CurrentPos.z = v3_Target.z;
            }
        }

        this.transform.localPosition = v3_CurrentPos;
    }

    public void move(Vector3 NewPosition)
    {
        v3_Target = NewPosition;
    }
}
