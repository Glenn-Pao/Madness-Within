using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HologramText : MonoBehaviour
{
	public GameObject GO_Head;
	public GameObject GO_ControllerR;
	public Vector3 v3_PositionOffset;

	Quaternion Q_UIRotation;

	bool b_isVisible = false;
	float f_fadeOutTimer = 0f;
	Color c_TextColor;
	Color c_LineColor;

	// Use this for initialization
	void Start ()
	{
		c_TextColor = this.GetComponent<Renderer> ().material.color;
		c_TextColor.a = 0f;

		c_LineColor = this.transform.FindChild ("Line").gameObject.GetComponent<MeshRenderer> ().material.color;
		c_LineColor.a = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (b_isVisible)
		{
			if (c_TextColor.a < 1f)
			{
				c_TextColor.a += Time.deltaTime * 2f;
				c_LineColor.a += Time.deltaTime * 2f;
			}
			else
			{
				c_TextColor.a = 1f;
				c_LineColor.a = 1f;
			}

			if (f_fadeOutTimer > 0f)
			{
				f_fadeOutTimer -= Time.deltaTime;
			}
			else
			{
				b_isVisible = false;
			}
		}
		else
		{
			if (c_TextColor.a > 0f)
			{
				c_TextColor.a -= Time.deltaTime * 2f;
				c_LineColor.a -= Time.deltaTime * 2f;
			}
			else
			{
				c_TextColor.a = 0f;
				c_LineColor.a = 0f;
			}
		}

		this.GetComponent<Renderer> ().material.color = c_TextColor;
		this.transform.FindChild ("Line").gameObject.GetComponent<MeshRenderer> ().material.color = c_LineColor;

		this.transform.position = v3_PositionOffset + GO_ControllerR.transform.position + (GO_ControllerR.transform.rotation * (new Vector3(0f, -0.025f, 0f)));
		this.transform.rotation = Quaternion.LookRotation(GO_ControllerR.transform.position - GO_Head.transform.position + v3_PositionOffset);
	}

	public void setMessage(string Text, float time)
	{
		GetComponent<TextMesh> ().text = Text;
		f_fadeOutTimer = time;
		b_isVisible = true;
	}
}
