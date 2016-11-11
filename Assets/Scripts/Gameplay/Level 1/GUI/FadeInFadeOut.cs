using UnityEngine;
using System.Collections;

//This script takes control of the fade in and fade out of the renderer material
//It should be attached to the UI that requires this feature
//Authored by Almeda Glenn
public class FadeInFadeOut : MonoBehaviour 
{
	private Color Output;			//the eventual output
	private Color Target;			//the target color to aim for
	public float speed = 2f;		//the speed at which it transitions

	public Color colorStart;		//starting color, defined by user
	public Color colorEnd;			//ending color, defined by user

	void Start()
	{
		Output = colorStart;		//Initialize the start color to output
		Target = colorEnd;			//Initialize the end color to target
	}
	void Update()
	{
		//whenever there is a difference between the target color and output color
		if (Target.a != Output.a) 
		{
			//get the difference between target and the output, and apply the "force" (speed)
			Output.a += (Target.a - Output.a) * Time.deltaTime * speed;

			//if the difference is small enough, snap output color to target color
			if (Mathf.Abs (Target.a - Output.a) < 0.01f) 
			{
				Output.a = Target.a;
			}
		}
		//set the output color to the material or else it will not update
		this.GetComponent<Renderer> ().material.color = Output;
	}
	public void FadeIn()
	{
		Target = colorStart;	//set the target color to colorStart
	}
	public void FadeOut()
	{
		Target = colorEnd;		//set the target color to colorEnd
	}

    public Color getOutput()
    {
        return Output;
    }
}
