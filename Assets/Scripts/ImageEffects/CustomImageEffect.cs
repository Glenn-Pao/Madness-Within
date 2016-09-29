using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CustomImageEffect : MonoBehaviour 
{
    public Material EffectMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        //render this source to that destination using this (effectmaterial) material
        Graphics.Blit(src, dst, EffectMaterial);
    }
}
