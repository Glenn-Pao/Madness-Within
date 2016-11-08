//This shader makes the text occluded when needed to avoid unnecessary confusion
//It allows the text to be seen on both sides. Use this if you need to provide a hologramic style of text in the 3D space
Shader "UI/3D Text Shader" 
{
	Properties
	{
		_MainTex("Font Texture", 2D) = "white" {}
		_Color("Text Color", Color) = (1,1,1,1)
	}

		SubShader
		{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off 
		Cull Off 
		ZWrite Off 
		Fog{ Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			Color[_Color]
			SetTexture[_MainTex]
			{
				combine primary, texture * primary
			}
		}
	}
}