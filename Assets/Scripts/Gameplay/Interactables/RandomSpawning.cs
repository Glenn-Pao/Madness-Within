using UnityEngine;
using System.Collections;

//This class will take care of randomizing spawning game objects in this particular spot
public class RandomSpawning : MonoBehaviour 
{
	[Tooltip("The target number of game objects that are available for randomized spawning")]
	public GameObject [] arrGO;	//an array of game objects

	private int number = 0;		//the number that is determined by the randomized function
	// Use this for initialization
	void Awake () 
	{
		RandomizeSpawn ();

		//run through the list
		for (int i = 0; i < arrGO.Length; i++) 
		{
			//if they are active and it's not the number from random roll, deactivate them
			if (arrGO [i].activeInHierarchy) 
			{
				arrGO [i].SetActive (false);
			}
		}
		//activate the chosen one..lol
		if (!arrGO [number].activeInHierarchy) 
		{
			arrGO [number].SetActive (true);
		}
	}

	//Roll the dice and return the number
	void RandomizeSpawn()
	{
		number = Random.Range (0, arrGO.Length);
		Debug.Log ("Number: " + number);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
