using UnityEngine;
using System.Collections;

//a trigger point for unlocking door
public class FailUnlockDoor : MonoBehaviour 
{
    private bool attemptedUnlock = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DrawerKey")
        {
            attemptedUnlock = true;
        }
    }
	public bool getAttemptedUnlock()
    {
        return attemptedUnlock;
    }
}
