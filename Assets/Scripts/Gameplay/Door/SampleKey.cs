using UnityEngine;
using System.Collections;

//This is a temporary key sample script only meant for the sample gameplay for presentation 2
public class SampleKey : MonoBehaviour 
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
