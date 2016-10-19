using UnityEngine;
using UnityEngine.UI;

//This class acts as a debug text corner for debugging purposes when testing new features
public class DebugText : MonoBehaviour
{
    [Tooltip("Toggles whether the Debug Text should be visible.")]
    public bool displayDebug = true;
    [Tooltip("The size of the text to be displayed.")]
    public int fontSize = 32;
    [Tooltip("The position of the text in headset view")]
    public Vector3 position = Vector3.zero;

    private Text text;

	// Use this for initialization
	private void Start ()
    {
        text = GetComponent<Text>();
        text.fontSize = fontSize;
        text.transform.localPosition = position;
	}

    private void Update()
    {
        if(text != null)
        {
            if(!displayDebug)
            {
                text.text = "";
            }
            else
            {
                text = getText();
            }
        }
    }
	
	public Text getText()
    {
        return text;
    }

    public void setText(string text)
    {
        this.text.text = text;
    }
}
