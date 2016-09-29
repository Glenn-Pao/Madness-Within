//This is a simple white shader
//For learning purposes only

Shader "BasicShaders/TheWhiteShader_Simple"
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
			};

			//defines what info we are passing into the fragment function
			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			//returns a v2f data
			v2f vert(appdata v)
			{
				v2f output;
				output.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				return output;
			}

			float4 frag(v2f i) : SV_Target
			{
				return float4(1, 1, 1, 1);
			}
			ENDCG
		}
	}
}
