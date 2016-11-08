//This shader makes the text occluded when needed to avoid unnecessary confusion
//You cannot see the text when it is back faced. Use this only when you need such behaviour

Shader "UI/3D Text Shader - Cull Back" 
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
		Cull Back 
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