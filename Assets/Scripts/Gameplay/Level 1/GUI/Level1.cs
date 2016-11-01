using UnityEngine;
using System.Collections;

//This script will tell the computer what GUI to display at when
public class Level1 : MonoBehaviour
{
    private bool isInsideGUISpace = false;		//inside the GUI Space?
    private float alpha = 0f;					//the alpha value
    private float lerp = 0f;					//lerp value
    private int num = 0;						//the number to display GUI help
    private bool chiselOnHand = false;			//whether chisel is on hand
    private bool hammerOnHand = false;			//whether hammer is on hand

    public GameObject chisel;					//the chisel
    public GameObject hammer;					//the hammer
    public FailUnlockDoor door;

    [Tooltip("The array of GUI Help Texts to be expected in this particular game object")]
    public GameObject[] GUIHelp;           //this is to cater for multiple GUI components
    [Tooltip("The duration of fade in and fade out")]
    public float duration = 1.0f;           //the target duration
    [Tooltip("The minimum alpha component of the object")]
    public float minAlpha = 0.0f;
    [Tooltip("The maximum alpha component of the object")]
    public float maxAlpha = 1.0f;

	//Just in case the Start doesn't work
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
	}
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
        if(door.getAttemptedUnlock())
        {
            if(!hammerOnHand && !chiselOnHand)
            {
                //display failed unlock
                num = 1;
            }
            if (hammerOnHand || chiselOnHand)
            {
                //display missing something
                num = 2;
            }
            else if (hammerOnHand && chiselOnHand)
            {
                //display destroy hinges
                num = 3;
            }
        }  
    }
    void OnTriggerEnter(Collider other)
    {
        //snap the alpha to original states before executing fade in
        if (alpha != minAlpha)
        {
            alpha = minAlpha;
        }

        //make sure it is the player that is inside the space
        if (other.gameObject.tag == "Player")
        {
			DetermineGUIDisplay();
            isInsideGUISpace = true;
        }
    }
    void OnTriggerStay()
    {		
		//The lerp time value based on target duration
        lerp = Mathf.PingPong(Time.time, duration) / duration;
        //if the player is inside the space, fade in the game objects
        if (isInsideGUISpace)
        {
            //interpolate when alpha is not max
            if (alpha != maxAlpha)
            {
                FadeIn(lerp);
            }
        }
        //if not, fade out the game objects
        else if (!isInsideGUISpace)
        {
            if (alpha != maxAlpha)
            {
                FadeOut(lerp);
            }
        }
    }
    void OnTriggerExit()
    {
        //snap the alpha to original states before executing fade out
		if (alpha != maxAlpha)
        {
			alpha = minAlpha;
			isInsideGUISpace = false;
        }      
    }
    void FadeIn(float lerp)
    {
        //interpolate if the alpha level is less than the maximum defined
        alpha = Mathf.Lerp(minAlpha, maxAlpha, lerp);
        //allocate the alpha calculation here
        GUIHelp[num].GetComponent<Renderer>().material.SetFloat("_Tween", alpha);
    }
    void FadeOut(float lerp)
    {
        //interpolate if the alpha level is less than the minimum defined
        alpha = Mathf.Lerp(maxAlpha, minAlpha, lerp);
        //allocate the alpha calculation here
        GUIHelp[num].GetComponent<Renderer>().material.SetFloat("_Tween", alpha);
    }
}
