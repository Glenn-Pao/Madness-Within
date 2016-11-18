using UnityEngine;
using System.Collections;

public class UI_Dial : MonoBehaviour
{
    public int i_CurrentDial = 0;
    public CaseLocker CL_CaseLocker;

    bool isReleased = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = this.GetComponent<PointerUIReceiver>().TriggerPressed();
        if (temp && !isReleased)
        {
            isReleased = true;
        }
        else if (!temp && isReleased)
        {
            isReleased = false;
            CL_CaseLocker.toggleDial(i_CurrentDial);
        }
    }
}
