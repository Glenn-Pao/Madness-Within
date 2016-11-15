using UnityEngine;
using System.Collections;

//this is meant to ignore the collisions of the player when interacting with the drawers or any other notable game objects
//attach this if you find that it is disrupting your gameplay
public class IgnoreCollisions : MonoBehaviour 
{
    private GameObject player;

	// Use this for initialization
	void Start () 
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == player.gameObject.tag)
        {
            Debug.Log("Trigger enter");
            player.GetComponent<Collider>().isTrigger = true;
            player.GetComponent<Rigidbody>().isKinematic = true;
        }     
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == player.gameObject.tag)
        {
            Debug.Log("Trigger exit");
            player.GetComponent<Collider>().isTrigger = false;
            player.GetComponent<Rigidbody>().isKinematic = false;
        }  
    }
}
