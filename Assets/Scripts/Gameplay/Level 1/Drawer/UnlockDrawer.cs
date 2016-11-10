using UnityEngine;
using System.Collections;

//This class will be used to help find out whether the drawer is unlocked
//It should only be attached to a drawer lock
public class UnlockDrawer : MonoBehaviour
{
    public bool keyUsed = false;			//see if the key is used or not
    public GameObject keyInserted;			//this key is already inserted

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DrawerKey")
        {
            Debug.Log("Collision");
            Destroy(other.gameObject);		//destroy the game object
            keyUsed = true;
        }
        else
        {
            Debug.Log("No collision");
        }
    }
    // Use this for initialization
    void Start()
    {
        //set false if it isn't already done
        if (keyInserted.activeInHierarchy)
        {
            keyInserted.SetActive(false);
        }
    }
    void Update()
    {
        if (keyUsed && !keyInserted.activeInHierarchy)
        {
            keyInserted.SetActive(true);
        }
    }
}
