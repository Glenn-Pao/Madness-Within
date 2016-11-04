using UnityEngine;
using System.Collections;

public class PointerUIController : MonoBehaviour
{
	public GameObject GO_Controller;
	public GameObject GO_Pointer;

	public Color C_DefaultColor;
	public Color C_HoverColor;
	public Color C_ClickColor;

	public float f_Range = 0.3f;

	Ray raycast;
	RaycastHit Rayhit;



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerPressed)
		{
			raycast.origin = GO_Controller.transform.position;
			raycast.direction =  GO_Controller.transform.rotation * new Vector3 (0, 0, 1);

			GO_Pointer.GetComponent<MeshFader> ().fadetoColour (C_DefaultColor);

			if (Physics.Raycast (raycast, out Rayhit, f_Range))
			{
				if (Rayhit.transform.gameObject.GetComponent<PointerUIReceiver> () != null)
				{
					Rayhit.transform.gameObject.GetComponent<PointerUIReceiver> ().Hovering ();
					GO_Pointer.GetComponent<MeshFader> ().fadetoColour (C_HoverColor);
			
					if (GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerClicked)
					{
						Rayhit.transform.gameObject.GetComponent<PointerUIReceiver>().Interact();
						GO_Pointer.GetComponent<MeshFader> ().fadetoColour (C_ClickColor);
					}
				}
			}
		}
		else
		{
			GO_Pointer.GetComponent<MeshFader> ().fadetoInvisible ();
		}
	}
}
