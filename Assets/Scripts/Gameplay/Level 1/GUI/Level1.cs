using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script will tell the computer what GUI to display at when
public class Level1 : MonoBehaviour
{
    private bool isInsideGUISpace = false;		//inside the GUI Space?
	public HologramText HologramUI;

    [Tooltip("The array of GUI Help Texts to be expected in this particular game object")]
    public TextMesh[] GUIHelp;           //this is to cater for multiple GUI components
	[Tooltip("This is the GUI Template that is used to display the text")]
	public GameObject GUITemplate;

    void OnTriggerEnter(Collider other)
    {
        //make sure it is the player that is inside the space
        if (other.gameObject.tag == "Player")
        {
            isInsideGUISpace = true;
        }
    }
    void OnTriggerExit()
    {
		isInsideGUISpace = false;
    }

	void Update()
	{
		if (isInsideGUISpace) 
		{
			HologramUI.setMessage ("The door is locked,\nneed to break it down..\nsomehow", 1.5f);
		}
	}
   	
}
