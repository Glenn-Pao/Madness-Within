using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
    bool b_Hovered = false;
    bool b_Interacted = false;

    bool b_InteractReleased = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hovering()
    {
        b_Hovered = true;
    }

    public void Interact()
    {
        b_Interacted = true;
    }

    public void setInteractReleased(bool isit)
    {
        b_InteractReleased = isit;
    }

    public bool Hovered()//Can only be used once per frame
    {
        if (b_Hovered)
        {
            b_Hovered = false;
            return true;
        }
        return false;
    }

    public bool Interacted()//Can only be used once per frame
    {
        if (b_Interacted)
        {
            b_Interacted = false;
            return true;
        }
        return false;
    }

    public bool InteractReleased()
    {
        return b_InteractReleased;
    }
}
