using UnityEngine;
using System.Collections;

//This class will take care of randomizing spawning game objects in this particular spot
public class RandomSpawning : MonoBehaviour 
{
	[Tooltip("The target number of chisels that are available for randomized spawning")]
	public GameObject [] arrChisels;	//an array of chisels
    [Tooltip("The target number of hammers that are available for randomized spawning")]
    public GameObject[] arrHammers;	    //an array of hammers

    private int numChisel = 0;		    //the number that is determined by the randomized function
    private int numHammer = 0;          //the number that is determined by random function
	// Use this for initialization
	void Awake () 
	{
		RandomizeSpawn ();
        ActivateChiselsAndHammers();		
    }
    void ActivateChiselsAndHammers()
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
        //run through the list
        for (int i = 0; i < arrHammers.Length; i++)
        {
            //if they are active and it's not the number from random roll, deactivate them
            if (arrHammers[i].activeInHierarchy)
            {
                arrHammers[i].SetActive(false);
            }
        }
        //activate the chosen one
        if (!arrChisels[numChisel].activeInHierarchy)
        {
            arrChisels[numChisel].SetActive(true);
        }
        //activate the chosen one
        if (!arrHammers[numHammer].activeInHierarchy)
        {
            arrHammers[numHammer].SetActive(true);
        }
    }

	//Roll the dice and return the number
	void RandomizeSpawn()
	{
        numChisel = Random.Range (0, arrChisels.Length);
        numHammer = Random.Range(0, arrHammers.Length);
        Debug.Log("Chisel Number: " + numChisel);
        Debug.Log("Hammer Number: " + numHammer);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
