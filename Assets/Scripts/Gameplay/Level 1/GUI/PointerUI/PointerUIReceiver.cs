using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
    bool b_Hovered = false;
    bool b_Interacted = false;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHovering(bool isit)
    {
        b_Hovered = isit;
    }

    public void setInteract(bool isit)
    {
        b_Interacted = isit;
    }

    public bool Hovered()//Can only be used once per frame
    {
        return b_Hovered;
        /*
        if (b_Hovered)
        {
            b_Hovered = false;
            return true;
        }
        return false;*/
    }

    public bool Interacted()//Can only be used once per frame
    {
        return b_Interacted;
        /*
        if (b_Interacted)   
        {
            b_Interacted = false;
            return true;
        }
        return false;*/
    }//*/
}
