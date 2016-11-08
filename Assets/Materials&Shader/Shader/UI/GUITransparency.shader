//This shader is originally intended for the GUI implemented in the game
//This may be used for other images that needs to use a surface shader with transparency
//Consider using "GUITransparency No Normal Map" if you do not need the Normal Map aspect to improve the performance
Shader "UI/GUITransparency" 
{
	Properties 
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Tween("Alpha Scale", Range(0, 2)) = 1
		_BumpMap("Normal Map", 2D) = "bump" { }
	}
	SubShader {
		Tags 
		{ 
			"Queue" = "Transparent"
			"RenderType"="Transparent" 
		}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha		//alpha blend

		CGPROGRAM
		// Physically based Standard lighting model with alpha scale factored in
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		sampler2D _MainTex;
		sampler2D _BumpMap;
		float _Tween;
		float3 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{

			float3 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a * _Tween;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
