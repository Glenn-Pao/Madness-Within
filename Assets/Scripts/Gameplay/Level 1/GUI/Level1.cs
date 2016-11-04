using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script will tell the computer what GUI to display at when
public class Level1 : MonoBehaviour
{
    private bool isInsideGUISpace = false;		//inside the GUI Space?
    private int num = 0;						//the number to display GUI help
    private bool chiselOnHand = false;			//whether chisel is on hand
    private bool hammerOnHand = false;			//whether hammer is on hand

    public GameObject chisel;					//the chisel
    public GameObject hammer;					//the hammer
    public FailUnlockDoor door;
	public HologramText HologramUI;

    [Tooltip("The array of GUI Help Texts to be expected in this particular game object")]
    public TextMesh[] GUIHelp;           //this is to cater for multiple GUI components
	[Tooltip("This is the GUI Template that is used to display the text")]
	public GameObject GUITemplate;

    //check that there is a chisel on one of the hands
    void CheckChiselOnHand()
    {
		if (chisel.GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed())
        {
			Debug.Log ("Chisel on hand");
			chiselOnHand = true;
        }
        else
        {
			Debug.Log ("Chisel not on hand");
            chiselOnHand = false;
        }
    }
    //check that there is a hammer on one of the hands
    void CheckHammerOnHand()
    {
		if (hammer.GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed())
        {
			Debug.Log ("Hammer on hand");
            hammerOnHand = true;
        }
        else
        {
			Debug.Log ("Hammer not on hand");
            hammerOnHand = false;
        }
    }
    //determine the number to display
    void DetermineGUIDisplay()
    {       
		if(!hammerOnHand && !chiselOnHand && !door.getAttemptedUnlock())
        {
            //display door is locked
            num = 0;
        }
        //if(door.getAttemptedUnlock())
        //{
        //    if(!hammerOnHand && !chiselOnHand)
        //    {
                //display failed unlock
        //        num = 1;
        //    }
        //    if (hammerOnHand || chiselOnHand)
        //    {
                //display missing something
        //        num = 2;
        //    }
        //    else if (hammerOnHand && chiselOnHand)
         //   {
                //display destroy hinges
         //       num = 3;
         //   }
        //}  
    }
    void OnTriggerEnter(Collider other)
    {
        //make sure it is the player that is inside the space
        if (other.gameObject.tag == "Player")
        {
			DetermineGUIDisplay();
            isInsideGUISpace = true;
        }
    }
    void OnTriggerExit()
    {
		isInsideGUISpace = false;
    }

	void Update()
	{
		if (chisel == null) 
		{
			chisel = GameObject.FindWithTag ("Chisel");		//find the chisel object
		}
		if (hammer == null) 
		{
			hammer = GameObject.FindWithTag ("Hammer");		//find the hammer object
		}

		CheckChiselOnHand ();
		CheckHammerOnHand ();

		if (isInsideGUISpace) 
		{
			HologramUI.setMessage ("The door is locked,\nneed to break it down..\nsomehow", 1.5f);
		}
	}
   	
}
