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
	[Tooltip("The door frame of the door.")]
	public GameObject DoorFrame;
    [Tooltip("You need this for debugging the feature")]
    public DebugText HingeStatus1;
    [Tooltip("You need this for debugging the feature")]
    public DebugText HingeStatus2;
    [Tooltip("The target door to be taken down")]
    public Door Door;
    [Tooltip("The mass you want your door to be")]
    public float targetMass = 1f;
    [Tooltip("The effectiveness factor of the force to be applied lowers with a higher number here")]
    public float targetDrag = 0f;
    [Tooltip("The angule flip lowers with a higher number")]
    public float targetAngularDrag = 0.05f;
	[Tooltip("The multiplier factor for the force to be applied")]
	public float multiplierFactor = 5;


    private bool isHit = false;             //check whether the door hinge was struck already
    private bool hingesAllBroken = false;   //check whether all of the door hinges were destroyed already
    private int numDestroyed = 0;           //the number of hinges destroyed
    private int targetNumDestroyed = 0;     //the length of the door hinges array

    //Initialize the door hinges length
    void Start()
    {        
        targetNumDestroyed = DoorHinges.Length;
        Debug.Log("Total number of hinges: " + targetNumDestroyed);
		Debug.Log ("Number destroyed: " + numDestroyed);
    }

    void BreakHinges()
    {
        //check that the number of hinges destroyed is NOT the same as the total number of hinges in this script
        if (numDestroyed != targetNumDestroyed)
        {
            //run through the list  of door hinges available
            for (int i = 0; i < DoorHinges.Length; i++)
            {
                //check that the chisel is on the door hinge first
                if (DoorHinges[i].getChiselStatus() )
                {
					HingeStatus1.setText (string.Format ("Num hits: {0:D}", DoorHinges [i].getHits ()));
					if (HammerHead.getHammerStatus ()) 
					{
						//check that it is not hit yet
						if (!isHit) {
							//ensure that the object is not destroyed yet
							if (DoorHinges [i].getHits () == DoorHinges [i].targetNum) {
								if (!DoorHinges [i].getIsDestroyed ()) {
									//make the thing fall off
									DoorHinges [i].GetComponent<Rigidbody> ().useGravity = true;
									DoorHinges [i].GetComponent<BoxCollider> ().isTrigger = false;
									numDestroyed += 1;  //increment the number of destroyed hinges
									DoorHinges [i].setIsDestroyed (true);
								}
							}
	                        //if it doesn't satisfy the requirement, increment the number
	                        else {
								DoorHinges [i].setHits (DoorHinges [i].getHits () + 1);
								isHit = true;
							}
						}
					}
					//when hammer is released from chisel, reset the hit boolean to allow for hitting
					else 
					{
						HingeStatus2.setText ("Shift hammer out");
						isHit = false;
					}
                }
            }
        }
        else
        {
            hingesAllBroken = true;
        }
    }
    //animate the door when pushed
    void DoorPushed()
    {
        //check that the time elapsed is long enough for the door to be pushed down
        if (Door.getPushDoor())
        {
            HingeStatus2.setText("Door opened");

            if (Door.GetComponent<Rigidbody>() == null)
            {
                Door.gameObject.AddComponent<Rigidbody>();
               
            }
			Door.GetComponent<BoxCollider> ().isTrigger = true;
			Door.GetComponent<Rigidbody>().mass = targetMass;
			Door.GetComponent<Rigidbody>().drag = targetDrag;
			Door.GetComponent<Rigidbody>().angularDrag = targetAngularDrag;
			Door.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * multiplierFactor, ForceMode.Force);
			//Door.GetComponent<Rigidbody>().AddRelativeTorque(-1, 0, 0, ForceMode.Acceleration);
			//Door.GetComponent<Rigidbody>().useGravity = true;
			Door.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //update the different mechanics as and when it is needed to avoid unnecessary calculations
        if (!hingesAllBroken)
        {
			Debug.Log ("Break Hinges active");
            BreakHinges();
        }
        else
        {
			Debug.Log ("Door pushed active");
            DoorPushed();

			if (Door.getPushDoor ()) 
			{
				if (!DoorFrame.GetComponent<BoxCollider> ().isTrigger) 
				{
					DoorFrame.GetComponent<BoxCollider> ().isTrigger = true;
					this.enabled = false;	//disable this behaviour to free space
				}
			}
        }
    }
}
