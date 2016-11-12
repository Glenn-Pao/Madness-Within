using UnityEngine;
using System.Collections;

//this class has the intentions of showing the highlight whenever the player is within the trigger zone
//Based on the feedback on some playtesters, this would help reduce the invasion of UI
public class ShowHighlight : MonoBehaviour 
{
    GameObject leftController;
    GameObject rightController;

    Vector3 v3_AveragePos;
    FadeInFadeOut fade;
    public float distance = 1.5f;

	// Use this for initialization
	void Start () 
    {
        //you need this to be able to show the highlight as and when needed
        if (this.GetComponent<FadeInFadeOut>() == null)
        {
            fade = this.gameObject.AddComponent<FadeInFadeOut>();
        }
        fade.colorStart = this.GetComponent<Renderer>().material.GetColor("_OutlineColor");
        fade.colorEnd = fade.colorStart;
        fade.colorEnd.a = 0;
	}
    void FindControllers()
    {
        if (leftController == null)
        {
            leftController = GameObject.FindGameObjectWithTag("LeftController");
        }
        if (rightController == null)
        {
            rightController = GameObject.FindGameObjectWithTag("RightController");
        }
    }
	// Update is called once per frame
	void Update () 
    {
        FindControllers();  //becomes useless after the 3rd frame in update

        //this is to avoid the null reference exception that is expected since controllers does not spawn at the start of program
        if(leftController != null && rightController !=  null)
        {
            v3_AveragePos = (leftController.transform.position + rightController.transform.position) * 0.5f;
            if (Vector3.SqrMagnitude(v3_AveragePos - this.transform.position) < distance)
            {
                fade.FadeIn();
            }
            else
            {
                fade.FadeOut();
            }
        }
        
        this.GetComponent<Renderer>().material.SetColor("_OutlineColor", fade.getOutput());
	}
}
