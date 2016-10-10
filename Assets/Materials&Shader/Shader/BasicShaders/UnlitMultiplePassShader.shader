//This is a surface shader that attempts to make the texture darker

Shader "BasicShaders/AdjustableTransparency"
{
	Properties
	{
		//Basic definition of texture
		_MainTex ("Color (RGB) Alpha (A)", 2D) = "white" {}
		_Tween("Alpha Scale", Range(0,2)) = 0		//a slider bar to define scale of alpha
	}
	SubShader
	{
		Tags
		{

			"Queue" = "Transparent"			//Anything alpha blended goes here
			"RenderType" = "Transparent"	//transparent rendering
			"IgnoreProjector" = "True"		//ignore the projector
		}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha		//alpha blend

		CGPROGRAM

		//standard lighting model and enable shadows on all light types
		#pragma surface surf Lambert alpha

		//Use shader model 3.0 target to get a nice looking lighting
		#pragma target 3.0

		sampler2D _MainTex;		//the main texture
		float _Tween;			//the slider value

		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a * _Tween;
		}
		ENDCG
	}
	Fallback "Diffuse"
}
