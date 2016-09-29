//This is a simple white shader
//For learning purposes only

Shader "BasicShaders/GrayscaleTiles"
{
	//the special properties of a shader. Important for texturing, alphas
	Properties
	{
		//Basic definition of texture
		_MainTex("Texture", 2D) = "white" {}
		//To provide the grayscale appearance on sprite
		//_Color("Color", Color) = (0.3, 0.59, 0.11, 1)
	}
	SubShader
		{
			Tags
			{
				//Render after Geometry and AlphaTest, in back-to-front order
				//Anything alpha-blended should go here
				"Queue" = "Transparent"
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

					float4 frag(v2f i) : SV_Target
					{
						//grayscaling the image
						float4 color = tex2D(_MainTex, i.uv * 2);
						float luminance = color.r * 0.3 + color.g * 0.59 + color.b * 0.11;
						
						float4 grayscale = float4(luminance, luminance, luminance, color.a);
						return grayscale;
					}
						ENDCG
				}
		}
}
