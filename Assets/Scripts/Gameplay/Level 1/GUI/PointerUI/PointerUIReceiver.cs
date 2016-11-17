using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
    bool b_Hovered = false;
    bool b_Interacted = false;
    bool b_HeldInteracted = false;

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

    public void setHeldInteracted(bool isit)
    {
        b_HeldInteracted = isit;
    }

    public bool Hovered()//Can only be used once per frame
    {
        return b_Hovered;
    }

    public bool Interacted()//Can only be used once per frame
    {
        return b_Interacted;
    }//*/

    public bool HeldInteracted()
    {
        return b_HeldInteracted;
    }
}
