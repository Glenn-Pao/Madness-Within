using UnityEngine;
using System.Collections;

//this class primarily is used to check collision with the chisel's back
public class Hammer : MonoBehaviour 
{
	public int hitCount = 0;
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Chisel Back") 
		{
			hitCount += 1;
		}
	}
}
