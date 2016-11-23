using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
    public bool b_EnableInteractTrigger = false;
    bool b_TouchpadPress = false;
    bool b_TriggerPressed = false;

    float f_TriggerTimer = 0f;
    float f_TouchpadTimer = 0f;
    //bool b_TriggerPressedWhenHeld = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (b_TriggerPressed)
        {
            if (f_TriggerTimer < 0)
            {
                f_TriggerTimer = 0f;
                b_TriggerPressed = false;
            }
            else
            {
                f_TriggerTimer -= Time.deltaTime;
            }
        }

        if (b_TouchpadPress)
        {
            if (f_TouchpadTimer < 0)
            {
                f_TouchpadTimer = 0f;
                b_TouchpadPress = false;
            }
            else
            {
                f_TouchpadTimer -= Time.deltaTime;
            }
        }
    }

    public void setTouchpad(bool isit)
    {
        if (isit)
        {
            f_TouchpadTimer = 0.1f;
            b_TouchpadPress = true;
        }
        else
        {
            b_TouchpadPress = false;
        }
    }

    public void setTrigger(bool isit)
    {
        if (isit)
        {
            f_TriggerTimer = 0.1f;
            b_TriggerPressed = true;
        }
        else
        {
            b_TriggerPressed = false;
        }
    }

    /*public void setTriggerPressWhenHeld(bool isit)
    {
        b_TriggerPressedWhenHeld = isit;
    }//*/

    public bool TouchpadPressed()//ShowText
    {
        return b_TouchpadPress;
    }

    public bool TriggerPressed()
    {
        return b_TriggerPressed;
    }//*/

    /*public bool TriggerPressedWhenHeld()
    {
        return b_TriggerPressedWhenHeld;
    }//*/
}
