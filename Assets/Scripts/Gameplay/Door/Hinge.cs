using UnityEngine;
using System.Collections;

//this is the hinge component of the chisel & hammer mechanics
public class Hinge : MonoBehaviour
{
    private bool ChiselInside = false;  //chisel inside trigger zone of hinge?
    private int numHits = 0;            //the number of hits already done

    [Tooltip("Adjust the number of hits to destroy the door hinge with hammer")]
    public int targetNum = 3;

    //when chisel enters trigger zone
	void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Chisel Front") 
		{			
			ChiselInside = true;
		}
    }
    //just another check to ensure nothing goes wrong
	void OnCollisionStay(Collision other)
    {
		if (other.gameObject.tag == "Chisel Front") 
		{
			ChiselInside = true;
		}
    }
    //when chisel exits hinge trigger zone
	void OnCollisionExit()
    {
        ChiselInside = false;
    }
    //the status of the chisel triggering hinge
	public bool getChiselStatus()
    {
        return ChiselInside;
    }
    //set the number of hits done
    public void setHits(int numHits)
    {
        this.numHits = numHits;
    }
    //get the number of hits done
    public int getHits()
    {
        return numHits;
    }
}
