//This is a simple white shader
//For learning purposes only

Shader "BasicShaders/SimpleCompoundColor"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			//define what info we are getting from each vertex on the mesh
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			//defines what info we are passing into the fragment function
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			//returns a v2f data
			v2f vert(appdata v)
			{
				v2f output;
				output.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				output.uv = v.uv;
				return output;
			}

			float4 frag(v2f i) : SV_Target
			{
				float4 color = float4(i.uv.r, i.uv.g, 1, 1);
				return color;
			}
				ENDCG
		}
	}
}
