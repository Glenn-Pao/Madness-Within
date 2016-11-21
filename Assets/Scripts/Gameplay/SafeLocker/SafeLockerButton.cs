using UnityEngine;
using System.Collections;

public class SafeLockerButton : MonoBehaviour
{
    public char input = '0';
    public SafeLocker SL_SafeLocker;
    bool isReleased = false;

    // Use this for initialization
    void Start()
    {
        if (this.GetComponent<PointerUIReceiver>() == null)
            this.gameObject.AddComponent<PointerUIReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = this.GetComponent<PointerUIReceiver>().TriggerPressed();
        if (temp && !isReleased)
        {
            isReleased = true;

            if (input == 'X' || input == 'x')
            {
                SL_SafeLocker.clearKey();
            }
            else if (input == 'Y')
            {
                if (SL_SafeLocker.isUnlocked())
                    SL_SafeLocker.b_CanOpen = true;
                else
                {
                    SL_SafeLocker.clearKey();
                    SL_SafeLocker.ShowError();
                }
            }
            else
                SL_SafeLocker.enterKey(input);
        }
        else if (!temp && isReleased)
        {
            isReleased = false; 
        }
    }
}
