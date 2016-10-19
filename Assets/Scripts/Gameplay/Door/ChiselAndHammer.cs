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
    public GameObject HammerHead;
    [Tooltip("This is to find the door hinge for the interaction with chisel front.")]
    public Hinge DoorHinge;
    [Tooltip("You need this for debugging the feature")]
    public DebugText text;

    // Use this for initialization
    void Start ()
    {
        DoorHinge.getChiselStatus();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateDebug();
	}
    void UpdateDebug()
    {
        if(text.displayDebug)
        {
            //Check the current state of the chisel and hinge status
            if(DoorHinge.getChiselStatus())
            {
                text.setText("Chisel in Hinge");
            }
            else
            {
                text.setText("Chisel not in Hinge");
            }
        }
    }
}
