using UnityEngine;
using System.Collections;

public class SafeLockerDisplay : MonoBehaviour
{
    public SafeLocker SL_SafeLocker;

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
        else
        {
            this.GetComponent<TextMesh>().text = SL_SafeLocker.s_CurPassword;
        }
        
    }
}
