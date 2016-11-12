using UnityEngine;
using System.Collections;

public class CheckDrawerStatus : MonoBehaviour 
{
    public UnlockDrawer drawer;
    public VRTK.VRTK_InteractableObject thisDrawer;
    public VRTK.VRTK_InteractableObject hammer;

	// Use this for initialization
	void Start () 
    {
        if (!drawer.keyUsed)
        {
            thisDrawer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
            hammer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!drawer.keyUsed)
        {
            thisDrawer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
            hammer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        }
        else if (drawer.keyUsed)
        {
            thisDrawer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
            hammer.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
        }
	}
}
