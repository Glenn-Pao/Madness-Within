using UnityEngine;
using System.Collections;

//The fade system that is necessary for the player's visual feedback
//This intends to provide players hints to solve the puzzles thrown at them
public class FadeGUI : MonoBehaviour
{
    private bool isInsideGUISpace = false;
    private float alpha = 0f;
    private float lerp = 0f;

    [Tooltip("The array of GUI Help Texts to be expected in this particular game object")]
    public GameObject [] GUIHelp;           //this is to cater for multiple GUI components
    [Tooltip("The duration of fade in and fade out")]
    public float duration = 1.0f;           //the target duration
    [Tooltip("The minimum alpha component of the object")]
    public float minAlpha = 0.0f;
    [Tooltip("The maximum alpha component of the object")]
    public float maxAlpha = 1.0f;

    void OnTriggerEnter(Collider other)
    {
        //snap the alpha to original states before executing fade in
        if(alpha != minAlpha)
        {
            alpha = minAlpha;
        }
        
        //make sure it is the player that is inside the space
        if(other.gameObject.tag == "Player")
        {
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
            if(alpha != maxAlpha)
            {
                FadeIn(lerp);
            }            
        }
        //if not, fade out the game objects
        else if(!isInsideGUISpace)
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
        for (int i = 0; i < GUIHelp.Length; i++)
        {
            GUIHelp[i].GetComponent<Renderer>().material.SetFloat("_Tween", alpha);
        }
    }
    void FadeOut(float lerp)
    {
        //interpolate if the alpha level is less than the minimum defined
        alpha = Mathf.Lerp(maxAlpha, minAlpha, lerp);
        //allocate the alpha calculation here
        for (int i = 0; i < GUIHelp.Length; i++)
        {
            GUIHelp[i].GetComponent<Renderer>().material.SetFloat("_Tween", alpha);
        }
    }
}
