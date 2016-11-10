using UnityEngine;
using System.Collections;

//To tackle the problem of sliding down the stairs when unintended, there is a need to change the speed
//whenever the player is near or on the stairs
public class ChangeSpeed : MonoBehaviour 
{
    public VRTK.VRTK_TouchpadWalking controller;
    public float changeSpeed = 2.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller.maxWalkSpeed = changeSpeed;
        }
    }
}
