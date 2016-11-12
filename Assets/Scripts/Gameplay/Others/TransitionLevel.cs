using UnityEngine;
using System.Collections;

public class TransitionLevel : MonoBehaviour 
{
    public HologramTextWorld text;      
    public ScreenFader fade;            //the fade manager
    public GameObject roomOne;          //room 1 with the puzzles, its checkpoint

    private PointerUITextMenu thisMenu;
    private GameObject player;          //the player

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
        thisMenu = this.GetComponent<PointerUITextMenu>();
    }
    void Transition()
    {
        if (text.getIsVisible() && !fade.isFaded() && thisMenu.getInteracted())
        {
            fade.fadeIn = false;
        }
        else if (fade.isFaded())
        {
            player.transform.position = roomOne.transform.position;
        }
    }

	// Update is called once per frame
	void Update () 
    {
        Transition();
	}
}
