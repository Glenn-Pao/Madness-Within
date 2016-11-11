using UnityEngine;
using System.Collections;

public class CheckDrawerStatus : MonoBehaviour 
{
    public UnlockDrawer drawer;
    public VRTK.VRTK_InteractableObject drawerInteract;

	// Use this for initialization
	void Start () 
    {
        if (drawerInteract == null)
        {
            drawerInteract = this.GetComponent<VRTK.VRTK_InteractableObject>();
        }
        if (!drawer.keyUsed)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        }
        else
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!drawer.keyUsed)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        }
        else if (drawer.keyUsed)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
        }
	}
}
