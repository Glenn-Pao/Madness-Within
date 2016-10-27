using UnityEngine;
using System.Collections;


//This is an experimental script
//An attempt to use this script to unlock the drawer
public class CheckDrawerStatus: MonoBehaviour 
{
	public UnlockDrawer keyhole;				//the keyhole

    void Awake()
    {
         
    }

	void Start()
	{
		//check if it is unlocked or not.
		if (!keyhole.knobTurned) 
		{
			this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = false;	//disable this behaviour for now
			//keyhole.GetComponent<VRTK.VRTK_Knob>().curValue = 0;
		} 
		else 
		{
			this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = true;	//enable this behaviour
		}
	}

	void Update()
	{
		if (keyhole.knobTurned) {
			//check that the behaviour is already enabled
			if (this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled) 
			{
				return;
			} 
			else 
			{
				this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = true;
			}
		} 
		else 
		{
			return;
		}
	}
}
