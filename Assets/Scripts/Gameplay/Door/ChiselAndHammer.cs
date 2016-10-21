using UnityEngine;
using UnityEngine.UI;

//The chisel and hammer mechanics
//This is intended to be a controller to check for the player input for these 3 objects
public class ChiselAndHammer : MonoBehaviour
{
    [Tooltip("This is to find the hammer head for the interaction with chisel back.")]
    public Hammer HammerHead;
    [Tooltip("This is to find the door hinges top for the interaction with chisel front.")]
	public Hinge[] DoorHinges;
    [Tooltip("You need this for debugging the feature")]
	public DebugText HingeStatus1;
    [Tooltip("You need this for debugging the feature")]
    public DebugText HingeStatus2;
	[Tooltip("The target door to be taken down")]
	public Door Door;


    private bool isHit = false;

	void BreakHinges()
	{        
		for (int i = 0; i < DoorHinges.Length; i++) 
		{
			//check that the chisel is on the door hinge first
			if (DoorHinges[i].getChiselStatus())
			{
				if (HammerHead.getHammerStatus ()) 
				{
					HingeStatus1.setText(string.Format("Num hits: {0:D}", DoorHinges[i].getHits()));

					//check that it is not hit yet
					if (!isHit)
					{
						//the number of times needed to destroy the hinge
						if (DoorHinges[i].getHits() == DoorHinges[i].targetNum)
						{
							//make the thing fall off
							DoorHinges[i].GetComponent<Rigidbody>().useGravity = true;
							DoorHinges[i].GetComponent<BoxCollider> ().isTrigger = false;
						}
						//if it doesn't satisfy the requirement, increment the number
						else
						{
							DoorHinges[i].setHits(DoorHinges[i].getHits() + 1);
							isHit = true;
						}
					}
				}
				//when hammer is released from chisel, reset the hit boolean to allow for hitting
				else
				{
					HingeStatus2.setText("Shift hammer out");
					isHit = false;
				}
			}

		}
    }
	void DoorPushed()
	{
		//check that the time elapsed is long enough for the door to be pushed down
		if (Door.getPushDoor ()) {
			HingeStatus2.setText ("Door opened");

			if (Door.GetComponent<Rigidbody> () == null) 
			{
				Door.gameObject.AddComponent<Rigidbody> ();
				Door.GetComponent<Rigidbody> ().mass = 1;
				Door.GetComponent<Rigidbody> ().drag = 0.1f;
				Door.GetComponent<Rigidbody> ().AddForce (Vector3.forward);
			} 
			else 
			{
				Door.GetComponent<Rigidbody> ().mass = 2;
				Door.GetComponent<Rigidbody> ().drag = 1f;
				Door.GetComponent<Rigidbody> ().isKinematic = false;
				Door.GetComponent<Rigidbody> ().AddForce (Vector3.forward);
			}
		} 
		else 
		{
			HingeStatus2.setText ("Door closed");
			if (Door.getTriggered ()) {
				HingeStatus1.setText ("Player interacted");
			} 
			else 
			{
				HingeStatus1.setText ("No interaction yet");
			}
		}
	}


	// Update is called once per frame
	void Update ()
    {
		//BreakHinges ();
		DoorPushed();
	}
}
