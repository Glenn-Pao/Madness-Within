using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionLevel : MonoBehaviour 
{
    public HologramTextWorld text;
    public ScreenFader fade;
    public GameObject thisObject;

    private PointerUITextMenu thisMenu;

    void Start()
    {
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
            SceneManager.LoadScene("Level 1");
        }
    }

	// Update is called once per frame
	void Update () 
    {
        Transition();
	}
}
