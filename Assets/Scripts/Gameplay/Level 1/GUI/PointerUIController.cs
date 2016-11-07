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

	Vector3 v3_defaultScale;
	Vector3 v3_currentScale;

	// Use this for initialization
	void Start ()
	{
		v3_defaultScale = GO_Pointer.transform.localScale;
		v3_currentScale = v3_defaultScale;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GO_Controller.GetComponent<VRTK.VRTK_ControllerEvents>().triggerPressed)
		{
			scaleZto (f_Range/3f * 2f);

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
			scaleZto (0);
			GO_Pointer.GetComponent<MeshFader> ().fadetoInvisible ();
		}

		GO_Pointer.transform.position.Set (GO_Pointer.transform.position.x, GO_Pointer.transform.position.y, v3_currentScale.z/3f);
		GO_Pointer.transform.localScale = v3_currentScale;
	}

	void scaleZto(float z)
	{
		v3_currentScale.z += (z - v3_currentScale.z) * Time.deltaTime * 6f;
	}
}
