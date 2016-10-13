using UnityEngine;
using System.Collections;

//This class will be used to help find out whether the drawer is unlocked
//It should only be attached to a drawer lock
public class UnlockDrawer : MonoBehaviour 
{
	public bool keyUsed = false;			//see if the key is used or not
	public GameObject keyInserted;			//this key is already inserted
	public bool knobTurned = false;			//knob turned to max?

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "DrawerKey") 
		{
			Destroy (other.gameObject);		//destroy the game object
			keyUsed = true;

		}
	}
	// Use this for initialization
	void Start () 
	{
		//set false if it isn't already done
		if (keyInserted.activeInHierarchy) 
		{
			keyInserted.SetActive (false);
		}
		this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = false;
	}

	//This function serves to check if the knob is twisted to maximum value
	void CheckUnlocked()
	{
		//check that the key is already used and the key is already inserted
		if (keyUsed) 
		{
			if (!keyInserted.activeInHierarchy) 
			{
				keyInserted.SetActive (true);
				this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = true;
			} 
			else 
			{
				if (this.GetComponent<VRTK.VRTK_Knob>().curValue == 4) 
				{
                    this.GetComponent<VRTK.VRTK_InteractableObject> ().enabled = false;
					this.GetComponent<VRTK.VRTK_Knob>().enabled = false;
					knobTurned = true;
				}
			}				
		} 
		else 
		{
			return;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		CheckUnlocked ();
	}
}
