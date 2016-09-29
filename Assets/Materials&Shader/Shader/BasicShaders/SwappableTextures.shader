//This is a simple white shader
//For learning purposes only

Shader "BasicShaders/TheTwoTexturesEffect"
{
	//the special properties of a shader. Important for texturing, alphas
	Properties
	{
		
		_MainTex("Texture", 2D) = "white" {}			//Basic definition of texture
		_SecondTex("Second Texture", 2D) = "white" {}	//The second Texture
		_Tween("Tween", Range(0,1)) = 0					//slide to display either 1 of the textures or both

	}
	SubShader
		{
			Tags
			{
				//Render after Geometry and AlphaTest, in back-to-front order
				//Anything alpha-blended should go here
				"Queue" = "Transparent"
				"PreviewType" = "Plane"
			}
			Pass
				{
					//Src = source, Dst = destination
					//SrcColor * SrcAlpha + DstColor * OneMinusSrcAlpha
					//Provides the standard transparency for the shader
					Blend SrcAlpha OneMinusSrcAlpha

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

					//sampling the textures to throw into the fragment component later
					sampler2D _MainTex;
					sampler2D _SecondTex;
					float _Tween;

					float4 frag(v2f i) : SV_Target
					{
						//display the textures depending on alpha number
						float4 color1 = tex2D(_MainTex, i.uv);
						float4 color2 = tex2D(_SecondTex, i.uv);

						//lerp between the 2 textures
						float4 color = lerp(color2, color1, _Tween);
						return color;
					}
						ENDCG
				}
		}
}
