﻿using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
    public bool b_EnableInteractTrigger = false;
    bool b_TouchpadPress = false;
    bool b_TriggerPressed = false;
    //bool b_TriggerPressedWhenHeld = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTouchpad(bool isit)
    {
        b_TouchpadPress = isit;
    }

    public void setTrigger(bool isit)
    {
        b_TriggerPressed = isit;
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