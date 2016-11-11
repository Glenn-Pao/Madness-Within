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
        if (this.GetComponent<FadeInFadeOut>() == null)
        {
            fade = this.gameObject.AddComponent<FadeInFadeOut>();
            fade.colorStart = this.GetComponent<Renderer>().material.GetColor("_OutlineColor");
            fade.colorEnd = fade.colorStart;
            fade.colorEnd.a = 0;
        }
	}

	// Update is called once per frame
	void Update () 
    {
        if (leftController == null)
        {
            leftController = GameObject.FindGameObjectWithTag("LeftController");
        }
        if (rightController == null)
        {
            rightController = GameObject.FindGameObjectWithTag("RightController");
        }
        v3_AveragePos = (leftController.transform.position + rightController.transform.position) * 0.5f;
        if (Vector3.SqrMagnitude(v3_AveragePos - this.transform.position) < distance)
        {
            fade.FadeIn();
        }
        else
        {
            fade.FadeOut();
        }
        this.GetComponent<Renderer>().material.SetColor("_OutlineColor", fade.getOutput());
	}
}
