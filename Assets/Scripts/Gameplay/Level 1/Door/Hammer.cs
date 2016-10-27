using UnityEngine;
using System.Collections;

//this is the hammer component of the chisel & hammer mechanics
public class Hammer : MonoBehaviour
{
	private bool HammerHit = false;		//hammer hits the chisel?

    //when hammer enters trigger zone
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Chisel Back") 
		{
			HammerHit = true;
		}
	}
    //just another check to ensure nothing goes wrong
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Chisel Back") 
		{
			HammerHit = true;
		}
	}
    //when hammer exits chisel trigger zone
	void OnTriggerExit()
	{
		HammerHit = false;
	}
    //the status of hammer hitting the chisel
	public bool getHammerStatus()
	{
		return HammerHit;
	}

}
