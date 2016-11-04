using UnityEngine;
using System.Collections;

public class PointerUIReceiver : MonoBehaviour
{
	public bool b_Hovered = false;
	public bool b_Interacted = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Hovering()
	{
		b_Hovered = true;
	}

	public void Interact()
	{
		b_Interacted = true;
	}

	public bool Hovered()//Can only be used once per frame
	{
		if (b_Hovered)
		{
			b_Hovered = false;
			return true;
		}
		return false;
	}

	public bool Interacted()//Can only be used once per frame
	{
		if (b_Interacted)
		{
			b_Interacted = false;
			return true;
		}
		return false;
	}
}
