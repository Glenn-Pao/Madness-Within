using UnityEngine;
using System.Collections;

//This class will take care of randomizing spawning game objects in this particular spot
public class RandomSpawning : MonoBehaviour 
{
	[Tooltip("The target number of chisels that are available for randomized spawning")]
	public GameObject [] arrChisels;	//an array of chisels

    private int numChisel = 0;		    //the number that is determined by the randomized function
	// Use this for initialization
	void Start () 
	{
		RandomizeSpawn ();
        ActivateChisels();		
    }
    void ActivateChisels()
    {
        //run through the list
        for (int i = 0; i < arrChisels.Length; i++)
        {
            //if they are active and it's not the number from random roll, deactivate them
            if (arrChisels[i].activeInHierarchy)
            {
                arrChisels[i].SetActive(false);
            }
        }    
        //activate the chosen one
        if (!arrChisels[numChisel].activeInHierarchy)
        {
            arrChisels[numChisel].SetActive(true);
        }
    }

	//Roll the dice and return the number
	void RandomizeSpawn()
	{
        numChisel = Random.Range (0, arrChisels.Length);
    }
}
