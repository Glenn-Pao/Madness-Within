using UnityEngine;
using System.Collections;

public class CheckDrawerStatus : MonoBehaviour 
{
    public UnlockDrawer drawer;

	// Use this for initialization
	void Start () 
    {
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
        if (!drawer.keyUsed && this.GetComponent<VRTK.VRTK_InteractableObject>().enabled)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        }
        else if (drawer.keyUsed && !this.GetComponent<VRTK.VRTK_InteractableObject>().enabled)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
        }
	}
}
