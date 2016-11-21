using UnityEngine;
using System.Collections;

//turns on gravity upon being grabbed
public class TurnOnGravity : MonoBehaviour 
{
    private Rigidbody rb;
    private Door door;
	// Use this for initialization
	void Start () 
    {
        if (rb == null)
        {
            rb = this.GetComponent<Rigidbody>();
        }
        if (door == null)
        {
            door = this.GetComponent<Door>();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (door.canBreakDoor() && !rb.useGravity)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
	}
}
