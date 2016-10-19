using UnityEngine;
using System.Collections;

//this is the hinge component of the chisel & hammer mechanics
public class Hinge : MonoBehaviour
{
    private bool ChiselInside = false;

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Chisel Front") 
		{			
			ChiselInside = true;
		}
    }

	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Chisel Front") 
		{
			ChiselInside = true;
		}
    }

	void OnTriggerExit()
    {
        ChiselInside = false;
    }

	public bool getChiselStatus()
    {
        return ChiselInside;
    }
}
