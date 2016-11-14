using UnityEngine;
using UnityEngine.UI;

//The chisel and hammer mechanics
//This is intended to be a controller to check for the player input for these 3 objects
public class ChiselAndHammer : MonoBehaviour
{
    [Tooltip("This is to find the hammer head for the interaction with chisel back.")]
    public GameObject HammerHead;
    [Tooltip("This is to find the door hinges top for the interaction with chisel front.")]
    public Hinge[] DoorHinges;
	[Tooltip("The door frame of the door.")]
	public GameObject DoorFrame;
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

    public RealSpace3D.RealSpace3D_AudioSource RS_HammerHitSound;
    public RealSpace3D.RealSpace3D_AudioSource RS_HingeBreakSound;

    private bool isHit = false;             //check whether the door hinge was struck already
    private bool hingesAllBroken = false;   //check whether all of the door hinges were destroyed already
    private int numDestroyed = 0;           //the number of hinges destroyed
    private int targetNumDestroyed = 0;     //the length of the door hinges array

    void Awake()
    {
        targetNumDestroyed = DoorHinges.Length;     //the number of targets to destroy
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
					if (HammerHead.GetComponent<Hammer>().getHammerStatus ()) 
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
                                    RS_HingeBreakSound.rs3d_PlaySound();
                                    DoorHinges [i].setIsDestroyed (true);
								}
							}
	                        //if it doesn't satisfy the requirement, increment the number
	                        else {
                                RS_HammerHitSound.rs3d_PlaySound();
								DoorHinges [i].setHits (DoorHinges [i].getHits () + 1);
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
        else
        {
            hingesAllBroken = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
		if (HammerHead == null)
		{
			HammerHead = GameObject.FindWithTag("Hammer Head");// FindGameObjectWithTag("Hammer Head");
		}
		//update the different mechanics as and when it is needed to avoid unnecessary calculations
        if (!hingesAllBroken)
        {
            BreakHinges();
        }
    }
}
