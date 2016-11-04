using UnityEngine;
using System.Collections;

public class HologramTextWorld : MonoBehaviour
{
	public GameObject GO_Head;

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
		//setMessage(new Vector3(1.466f, 2.85f, -20.85f), "TEST MESSAGE PLS\nIGNORE", 10f);
		
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

		this.transform.rotation = Quaternion.LookRotation(this.transform.position - GO_Head.transform.position);
	}

	public void setMessage(Vector3 Position, string Text, float Time)
	{
		this.transform.position = Position;
		GetComponent<TextMesh> ().text = Text;
		f_fadeOutTimer = Time;
		b_isVisible = true;
	}
}
