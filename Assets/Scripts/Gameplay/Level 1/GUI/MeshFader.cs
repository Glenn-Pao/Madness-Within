﻿using UnityEngine;
using System.Collections;

public class MeshFader : MonoBehaviour
{
	//public bool b_isVisible = false;
	public float f_fadeSpeed = 3f;
	Color c_Color;
	Color c_ColorTarget;

	// Use this for initialization
	void Start ()
	{
		c_Color = this.GetComponent<Renderer> ().material.color;
		c_Color.a = 0f;

		c_ColorTarget = c_Color;
	}

	// Update is called once per frame
	void Update ()
	{
		if (c_Color.a != c_ColorTarget.a)
		{
			c_Color.a += (c_ColorTarget.a - c_Color.a) * Time.deltaTime * f_fadeSpeed;

			if (Mathf.Abs (c_ColorTarget.a - c_Color.a) < 0.05f)
			{
				c_Color.a = c_ColorTarget.a;
			}
		}

		if (c_Color.r != c_ColorTarget.r)
		{
			c_Color.r += (c_ColorTarget.r - c_Color.r) * Time.deltaTime * f_fadeSpeed;

			if (Mathf.Abs (c_ColorTarget.r - c_Color.r) < 0.05f)
			{
				c_Color.r = c_ColorTarget.r;
			}
		}

		if (c_Color.g != c_ColorTarget.g)
		{
			c_Color.g += (c_ColorTarget.g - c_Color.g) * Time.deltaTime * f_fadeSpeed;

			if (Mathf.Abs (c_ColorTarget.g - c_Color.g) < 0.05f)
			{
				c_Color.g = c_ColorTarget.g;
			}
		}

		if (c_Color.b != c_ColorTarget.b)
		{
			c_Color.b += (c_ColorTarget.b - c_Color.b) * Time.deltaTime * f_fadeSpeed;

			if (Mathf.Abs (c_ColorTarget.b - c_Color.b) < 0.05f)
			{
				c_Color.b = c_ColorTarget.b;
			}
		}

		this.GetComponent<Renderer> ().material.color = c_Color;
	}

	public void fadetoColour(Color color)
	{
		c_ColorTarget = color;
	}

	public void fadetoInvisible()
	{
		c_ColorTarget.a = 0f;
	}

	public void fadetoVisible()
	{
		c_ColorTarget.a = 1f;
	}
}
