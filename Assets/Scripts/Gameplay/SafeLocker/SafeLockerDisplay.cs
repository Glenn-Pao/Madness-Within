using UnityEngine;
using System.Collections;

public class SafeLockerDisplay : MonoBehaviour
{
    public SafeLocker SL_SafeLocker;
    bool b_ShowError = false;
    float f_ErrorTime = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SL_SafeLocker.b_CanOpen)
        {
            this.GetComponent<TextMesh>().text = "SUCCESS";
        }
        else if (b_ShowError)
        {
            this.GetComponent<TextMesh>().text = "ERROR";

            f_ErrorTime -= Time.deltaTime;

            if (f_ErrorTime <= 0f)
            {
                b_ShowError = false;
            }
        }
        else
        {
            this.GetComponent<TextMesh>().text = SL_SafeLocker.s_CurPassword;
        }

        if (SL_SafeLocker.b_ShowError)
        {
            ShowError();
            SL_SafeLocker.b_ShowError = false;
        }
        
    }

    public void ShowError()
    {
        f_ErrorTime = 2f;
        b_ShowError = true;
    }
}
