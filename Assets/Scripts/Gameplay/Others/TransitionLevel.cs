using UnityEngine;
using System.Collections;

public class TransitionLevel : MonoBehaviour 
{
    public HologramTextWorld text;      
    public ScreenFader fade;            //the fade manager
    public GameObject roomOne;          //room 1 with the puzzles, its checkpoint

    private PointerUITextMenu thisMenu;
    private GameObject player;          //the player
    private GameObject tutorialLevel;   //the tutorial level
    private GameObject mainLevel;       //the main level

    void Start()
    {
        if(text == null)
        {
            text = GameObject.FindGameObjectWithTag("HologramTextWorld").GetComponent<HologramTextWorld>();
        }
        if(fade == null)
        {
            fade = GameObject.FindGameObjectWithTag("FadeManager").GetComponent<ScreenFader>();
        }
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(tutorialLevel == null)
        {
            tutorialLevel = GameObject.FindGameObjectWithTag("TutorialLevel");
            //Debug.Log(tutorialLevel);
        }
        if (mainLevel == null)
        {
            mainLevel = GameObject.FindGameObjectWithTag("MainLevel");
            mainLevel.SetActive(false);
            //Debug.Log(mainLevel);
        }
        thisMenu = this.GetComponent<PointerUITextMenu>();
    }
    void Transition()
    {
        if (text.getIsVisible() && !fade.isFaded() && thisMenu.getInteracted())
        {
            fade.fadeIn = false;    //fade out
        }
        else if (fade.isFaded())
        {
            SwapLevel();
            fade.fadeIn = true;     //activate the fade in   
        }
    }
    
    //swap the level
    void SwapLevel()
    {
        mainLevel.SetActive(true);                              //render main level
        player.transform.position = roomOne.transform.position;
        tutorialLevel.SetActive(false);                         //derender tutorial level
    }
	// Update is called once per frame
	void Update () 
    {
        Transition();
	}
}
