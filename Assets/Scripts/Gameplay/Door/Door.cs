using UnityEngine;
using System.Collections;

//the door that will be brought down will need to take in the time
public class Door : MonoBehaviour 
{
	private bool pushDoor = false;		//whether the door is pushed already
	private float deltaTime = 0;		//the delta time
	public float targetTime = 3;		//target time length

	private bool leftControllerActive = false;	//if true, left controller is active
	private bool rightControllerActive = false;	//if true, right controller is active

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "LeftController") 
		{
			leftControllerActive = true;
		}
		if (other.gameObject.tag == "RightController") 
		{
			rightControllerActive = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "LeftController" || other.gameObject.tag == "RightController") 
		{
			//start the timer
			deltaTime += Time.deltaTime;

			//after a certain amount of time, door will be pushed
			if (deltaTime > targetTime) {
				pushDoor = true;
			}
		}
	}

	void OnTriggerExit()
	{
		deltaTime = 0;
		leftControllerActive = false;
		rightControllerActive = false;
	}

	public bool getPushDoor()
	{
		return pushDoor;
	}
	public bool getLeftTriggered()
	{
		return leftControllerActive;
	}
	public bool getRightTriggered()
	{
		return rightControllerActive;
	}
}
