using UnityEngine;
using System.Collections;

//this is the hammer component of the chisel & hammer mechanics
public class Hammer : MonoBehaviour
{
	private bool HammerHit = false;		//hammer hits the chisel?
	private int numHits = 0;			//the number of hits already done

	[Tooltip("Adjust the number of hits to destroy the door hinge with hammer")]
	public int targetNum = 3;			

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Chisel Back") 
		{
			HammerHit = true;
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Chisel Back") 
		{
			HammerHit = true;
		}
	}

	void OnTriggerExit()
	{
		HammerHit = false;
	}

	public bool getHammerStatus()
	{
		return HammerHit;
	}
	public void setHits(int numHits)
	{
		this.numHits = numHits;
	}
	public int getHits()
	{
		return numHits;
	}
}
