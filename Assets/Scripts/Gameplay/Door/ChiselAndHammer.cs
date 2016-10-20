using UnityEngine;
using UnityEngine.UI;

//The chisel and hammer mechanics
//This is intended to be a controller to check for the player input for these 3 objects
public class ChiselAndHammer : MonoBehaviour
{
    [Tooltip("This is to indicate the back of the chisel for the hammer to hit.")]
    public GameObject ChiselBack;
    [Tooltip("This is to find the chisel's front to interact with the door hinge.")]
    public GameObject ChiselFront;
    [Tooltip("This is to find the hammer head for the interaction with chisel back.")]
    public Hammer HammerHead;
    [Tooltip("This is to find the door hinges for the interaction with chisel front.")]
    public Hinge [] DoorHinge;
    [Tooltip("You need this for debugging the feature")]
	public DebugText HingeStatus1;
    [Tooltip("You need this for debugging the feature")]
    public DebugText HingeStatus2;

    private bool isHit = false;

	void BreakDoor()
	{
        HingeStatus1.setText(string.Format("Num hits: {0:D}", DoorHinge[0].getHits()));
        HingeStatus2.setText(string.Format("Num hits: {0:D}", DoorHinge[1].getHits()));

        //run through this loop
        for (int i = 0; i < DoorHinge.Length; i++)
        {
            //check that the chisel is on the door hinge first
            if (DoorHinge[i].getChiselStatus())
            {
                //check that the hammer is hitting the chisel
                if (HammerHead.getHammerStatus())
                {
                    //check that it is not hit yet
                    if (!isHit)
                    {
                        //the number of times needed to destroy the hinge
                        if (DoorHinge[i].getHits() == DoorHinge[i].targetNum)
                        {
							//make the thing fall off
                            DoorHinge[i].GetComponent<Rigidbody>().useGravity = true;
                        }
                        //if it doesn't satisfy the requirement, increment the number
                        else
                        {
                            DoorHinge[i].setHits(DoorHinge[i].getHits() + 1);
                            isHit = true;
                        }
                    }
                }
                //when hammer is released from chisel, reset the hit boolean to allow for hitting
                else
                {
                    isHit = false;
                }
            }
        }   
    }

	// Update is called once per frame
	void Update ()
    {
		BreakDoor ();
	}
}
