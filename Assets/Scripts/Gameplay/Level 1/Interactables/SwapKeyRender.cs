using UnityEngine;
using System.Collections;

//This script handles the rendering of the key on the key hole knob
public class SwapKeyRender : MonoBehaviour 
{
	public GameObject otherKey;		//the other key

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Door") 
		{
			otherKey.SetActive (true);
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () 
	{
		if (otherKey.gameObject.activeInHierarchy) 
		{
			otherKey.gameObject.SetActive (false);
		}
	}
	
}
