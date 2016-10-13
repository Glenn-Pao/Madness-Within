using UnityEngine;
using System.Collections;

public class CheckDoorStatus : MonoBehaviour 
{
	public UnlockDoor keyhole;				//the keyhole

	void Awake()
	{

	}

	void Start()
	{
		//check if it is unlocked or not.
		if (!keyhole.keyUsed) 
		{
			this.GetComponentInChildren<VRTK.VRTK_InteractableObject> ().enabled = false;	//disable this behaviour for now
			//keyhole.GetComponent<VRTK.VRTK_Knob>().curValue = 0;
		} 
		else 
		{
			this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = true;	//enable this behaviour
		}
	}

	void Update()
	{
		if (keyhole.keyUsed) {
			//check that the behaviour is already enabled
			if (this.GetComponent<VRTK.VRTK_Door> ().openOutward && this.GetComponent<VRTK.VRTK_Door>().openInward) 
			{
				return;
			} 
			else 
			{
				this.GetComponent<VRTK.VRTK_Door> ().openOutward = true;
				this.GetComponent<VRTK.VRTK_Door> ().openInward = true;
			}
		} 
		else 
		{
			return;
		}
	}
}
