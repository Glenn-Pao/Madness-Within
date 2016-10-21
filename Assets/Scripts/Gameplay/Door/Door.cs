using UnityEngine;
using System.Collections;

//the door that will be brought down will need to take in the time
public class Door : MonoBehaviour 
{
	private bool triggered = false;		//triggered the door mechanic?
	private bool pushDoor = false;		//whether the door is pushed already
	private float deltaTime = 0;		//the delta time
	public float targetTime = 3;		//target time length

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("Door collided");
			triggered = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
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
		triggered = false;
	}

	public bool getPushDoor()
	{
		return pushDoor;
	}
	public bool getTriggered()
	{
		return triggered;
	}
}
