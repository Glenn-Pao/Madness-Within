using UnityEngine;
using System.Collections;

//Unlock the door using the chisel and hammer
//There is a need to find out whether the hammer strikes the chisel's back
//It needs to be done 3 times before it unlocks
public class UnlockDoor : MonoBehaviour 
{
	//public CheckDoorStatus status;
	public bool keyUsed = false;			//see if the key is used or not
	public GameObject keyInserted;			//this key is already inserted
	public GameObject mainDoor;
	public GameObject handles;

	void OnCollisionEnter(Collision other)
	{
		Debug.Log ("Collision Enter");
		if (other.gameObject.tag == "DoorKey") 
		{
			Destroy (other.gameObject);		//destroy the game object
			keyUsed = true;
		}
	}

	void Start()
	{
		if(keyInserted.activeInHierarchy)
		{
			keyInserted.SetActive (false);
			handles.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
		}
	}

	void CheckUnlocked()
	{
		//check that the key is already used and the key is already inserted
		if (keyUsed) 
		{
			if (!keyInserted.activeInHierarchy) 
			{
				keyInserted.SetActive (true);
				mainDoor.GetComponent<VRTK.VRTK_Door>(). openOutward = true;
				mainDoor.GetComponent<VRTK.VRTK_Door> ().openInward = true;
				handles.GetComponentInParent<VRTK.VRTK_InteractableObject> ().enabled = true;
			} 
			else 
			{
				return;
			}				
		}
	}

	// Update is called once per frame
	void Update () 
	{
		CheckUnlocked ();
	}
}
