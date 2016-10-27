using UnityEngine;
using System.Collections;

//If the player falls off the world, this script attempts to reset the position of the player for them to continue playing
//This class may be used to create checkpoints next time
public class ResetPosition : MonoBehaviour 
{
	public GameObject CameraVR;		//the camera
	public Transform initPos;		//initial position of the camera

	//When the player collides to this, reset the position
	void OnCollisionEnter()
	{
		CameraVR.transform.position = initPos.position;
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
