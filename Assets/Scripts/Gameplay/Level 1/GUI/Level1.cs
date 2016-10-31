using UnityEngine;
using System.Collections;

//This script will tell the computer what GUI to display at when
public class Level1 : MonoBehaviour
{
    private bool isInsideGUISpace = false;
    private float alpha = 0f;
    private float lerp = 0f;
    private int num = 0;
    private bool chiselOnHand = false;
    private bool hammerOnHand = false;

    public GameObject leftController;
    public GameObject rightController;
    public FailUnlockDoor door;

    [Tooltip("The array of GUI Help Texts to be expected in this particular game object")]
    public GameObject[] GUIHelp;           //this is to cater for multiple GUI components
    [Tooltip("The duration of fade in and fade out")]
    public float duration = 1.0f;           //the target duration
    [Tooltip("The minimum alpha component of the object")]
    public float minAlpha = 0.0f;
    [Tooltip("The maximum alpha component of the object")]
    public float maxAlpha = 1.0f;

    //check that there is a chisel on one of the hands
    void CheckChiselOnHand()
    {
        if (leftController.transform.FindChild("Chisel") || rightController.transform.FindChild("Chisel"))
        {
            chiselOnHand = true;
        }
        else
        {
            chiselOnHand = false;
        }
    }
    //check that there is a hammer on one of the hands
    void CheckHammerOnHand()
    {
        if (leftController.transform.FindChild("Hammer") || rightController.transform.FindChild("Hammer"))
        {
            hammerOnHand = true;
        }
        else
        {
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
            else if (hammerOnHand || chiselOnHand)
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
            if (alpha != minAlpha)
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
            alpha = maxAlpha;
        }
        isInsideGUISpace = false;
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
