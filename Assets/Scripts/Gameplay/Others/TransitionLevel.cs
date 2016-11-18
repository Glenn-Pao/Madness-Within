using UnityEngine;
using System.Collections;

public class TransitionLevel : MonoBehaviour 
{    
    public ScreenFader fade;                        //the fade manager
    public GameObject tutorialRoom;                 //tutorial room
    public GameObject mainRoom;                     //room and corridor with puzzles
    public GameObject mainRoomSpawningPoint;        //the checkpoint
    public PointerUIReceiver UI_InteractTrigger;
    

    private GameObject player;                      //player object
    bool b_isReleased = false;                      //released or not?

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (UI_InteractTrigger == null)
        {
            if (this.GetComponent<PointerUIReceiver>() != null)
            {
                UI_InteractTrigger = this.GetComponent<PointerUIReceiver>();
            }
            else
            {
                UI_InteractTrigger = this.gameObject.AddComponent<PointerUIReceiver>();
            }
        }
        mainRoom.SetActive(false);
    }
    void Transition()
    {
        if(UI_InteractTrigger.TriggerPressed() && !b_isReleased)
        {
            b_isReleased = true;
        }
        else if (!UI_InteractTrigger.TriggerPressed() && b_isReleased)
        {
            b_isReleased = false;

            if (fade.fadeIn)
            {
                fade.fadeIn = false;
            }
        }
        if (fade.isFaded())
        {
            SwapLevel();
            fade.fadeIn = true;     //activate the fade in   
        }
    }
    
    //swap the level
    void SwapLevel()
    {
        mainRoom.SetActive(true);                              //render main level
        player.transform.position = mainRoomSpawningPoint.transform.position;
        tutorialRoom.SetActive(false);                         //derender tutorial level
    }
	// Update is called once per frame
	void Update () 
    {
        Transition();
	}
}
